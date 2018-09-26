using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace hc6_config
{
    // HC6 module states.
    public enum HC6State
    {
        HC6Idle,
        HC6Version,
        HC6Name,
        HC6Password,
        HC6Baud,
        HC6Parity
    }

    // HC6 related error codes.
    public enum HC6Error
    {
        HC6Success,
        HC6ErrorPortClosed,
        HC6ErrorCommunication
    }
    
    public partial class frmMain : Form
    {               
        private static SerialPort _serialPort = null;
        private HC6State _deviceState = HC6State.HC6Idle;

        private string _devName = "";
        private string _devPinCode = "";
        private int _devBaudRate = 0;
        private int _devParity = 0;
        
        private string HC6ErrorToString(HC6Error errCode)
        {
            switch (errCode)
            {
                case HC6Error.HC6ErrorPortClosed:
                    return "COM port is closed or unusable.";
                case HC6Error.HC6ErrorCommunication:
                    return "Communication error with HC6 module.";
                default:
                    return "OK";
            }
        }

        private void updateErrorUI()
        {
            txtStatus.Text = "Unable to connect.";
            setConnectionMode(false);
        }

        private void setConnectionMode(bool isConnected)
        {
            grpBluetooth.Enabled = isConnected;
            btnConnect.Enabled = !isConnected;
            btnDisconnect.Enabled = grpBluetooth.Enabled;
            txtSerialPort.Enabled = btnConnect.Enabled;
            txtSerialBaud.Enabled = btnConnect.Enabled;
        }

        private HC6Error sendAtCommand(char[] cmdBuffer)
        {
            try
            {
                _serialPort.Write(cmdBuffer, 0, cmdBuffer.Length);
                return HC6Error.HC6Success;
            }
            catch (Exception)
            {
                // Possible exception in this stage is communication related exceptions.
                return HC6Error.HC6ErrorCommunication;
            }
        }

        public frmMain()
        {
            InitializeComponent();

            _deviceState = HC6State.HC6Idle;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Setup UI defaults.
            cmbDevBaud.SelectedIndex = 3;
            cmbDevParity.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            int serialBaudRate = 0;

            txtStatus.Text = string.Empty;
                        
            // Check for serial port name is available.
            if (txtSerialPort.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Serial port is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialPort.Focus();
                return;
            }

            // Check serial port baud rate is available.
            if (txtSerialBaud.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Serial port baud rate is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialBaud.Focus();
                return;
            }

            // Check for valid serial port baud rate.
            if (!int.TryParse(txtSerialBaud.Text.Trim(), out serialBaudRate))
            {
                MessageBox.Show("Serial port baud rate is invalid.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSerialBaud.Focus();
                return;
            }
          
            try
            {
                // Trying to establish connection with specified COM port.
                btnConnect.Enabled = false;
                txtStatus.Text = "Connecting...";

                _serialPort = new SerialPort(txtSerialPort.Text.Trim(), serialBaudRate);
                _serialPort.DataReceived += _serialPort_DataReceived;
                _serialPort.Open();

                // Try to get version information from bluetooth module.
                bwDevInfo.RunWorkerAsync();     
            }
            catch (Exception ex)
            {
                // Handle exceptions in COM port open phase.
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);                
                updateErrorUI();
            }
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Wait for addtional data to get filled into COM port read buffer.
            System.Threading.Thread.Sleep(500);


            // Check for data related with HC6 version.
            if (_deviceState == HC6State.HC6Version)
            {
                string retMessage = _serialPort.ReadExisting();

                // Stop timeout counter.
                tmDevProbe.Enabled = false; 

                if(retMessage.Trim().Length > 0)
                {                   
                    // Trim "OK" prefix from the received version string.
                    if (retMessage.Substring(0, 2).ToUpper() == "OK")
                    {
                        retMessage = retMessage.Substring(2, retMessage.Length - 2);
                    }

                    // Update UI with received version information.
                    txtVersion.Invoke((MethodInvoker)delegate
                    {
                        txtVersion.Text = retMessage;
                    });
                }
                
                // Application finished initialization.             
                _deviceState = HC6State.HC6Idle;
                this.Invoke((MethodInvoker)delegate
                {
                    setConnectionMode(true);
                });                
            }
            else if (_deviceState == HC6State.HC6Name) 
            {                               
                // Device name update completed. Move to next update state.
                System.Threading.Thread.Sleep(50);
                _deviceState = HC6State.HC6Password;
                bwDevUpdate.RunWorkerAsync();
            }
            else if (_deviceState == HC6State.HC6Password) 
            {
                // Device pair password update completed. Move to next update state.
                System.Threading.Thread.Sleep(50);
                _deviceState = HC6State.HC6Baud;
                bwDevUpdate.RunWorkerAsync();
            }
            else if(_deviceState == HC6State.HC6Baud)
            {
                // Device baud rate update completed. Move to next update state.
                System.Threading.Thread.Sleep(50);
                _deviceState = HC6State.HC6Parity;
                bwDevUpdate.RunWorkerAsync();
            }
            else if (_deviceState == HC6State.HC6Parity) 
            {
                // Device parity check type updated. Move to next update state.
                this.Invoke((MethodInvoker)delegate
                {
                    btnDevUpdate.Enabled = true;
                    MessageBox.Show("Bluetooth module configuration updated successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
        }

        private void bwDevInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check COM port is still open.
            if (_serialPort.IsOpen)
            {
                // Request version information from bluetooth module.
                _deviceState = HC6State.HC6Version;
                e.Result = sendAtCommand(("AT+VERSION").ToCharArray());                
            }
            else
            {
                // Return port closed status in thread results.
                e.Result = HC6Error.HC6ErrorPortClosed;
            }
        }

        private void bwDevInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check for any worker related error codes.
            if (((HC6Error)e.Result) != HC6Error.HC6Success)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtStatus.Text = HC6ErrorToString((HC6Error)e.Result);

                    // Switch application to idle state due to error.
                    _deviceState = HC6State.HC6Idle;
                    updateErrorUI();
                });

                return;
            }
            
            // Now application should received information from bluetooth module...
            txtStatus.Text = "Connected";
            tmDevProbe.Enabled = true;
        }

        private void tmDevProbe_Tick(object sender, EventArgs e)
        {
            // Bluetooth response time is expired. Looks like device is not attached to 
            // serial communication module.
            tmDevProbe.Enabled = false;            
            setConnectionMode(false);

            txtStatus.Text = "Bluetooth module not responding.";
            MessageBox.Show("Bletooth module not responding. Check bluetooth module is power on and its I/O connections.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }

        private void btnDevUpdate_Click(object sender, EventArgs e)
        {
            int pairPassword = 0;
            
            // Validate bluettoth module's device name.
            if (txtDevName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bluetooth module name is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDevName.Focus();
                return;
            }

            // Validate bluettoth pair password.
            if (txtDevPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bluetooth pair password is not specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDevPassword.Focus();
                return;
            }

            // Check format of the bluetooth pair password.
            if ((!int.TryParse(txtDevPassword.Text.Trim(), out pairPassword)) || (txtDevPassword.Text.Trim().Length != 4))
            {
                MessageBox.Show("Bluetooth pair password is not valid.\nPair password should be 4-bit number.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDevPassword.Focus();
                return;
            }

            _devName = txtDevName.Text.Trim();
            _devPinCode = txtDevPassword.Text.Trim();
            _devBaudRate = cmbDevBaud.SelectedIndex;
            _devParity = cmbDevParity.SelectedIndex;

            btnDevUpdate.Enabled = false;

            // Start module configuration update process.
            _deviceState = HC6State.HC6Name;
            bwDevUpdate.RunWorkerAsync();
        }

        private void bwDevUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            // Check COM port is still open.
            if (_serialPort.IsOpen)
            {
                // Update display name of the bluetooth module.
                if (_deviceState == HC6State.HC6Name)
                {                    
                    e.Result = sendAtCommand(("AT+NAME" + _devName).ToCharArray());  
                }
                else if (_deviceState == HC6State.HC6Password) 
                {
                    // Update bluetooth pair password.
                    e.Result = sendAtCommand(("AT+PIN" + _devPinCode).ToCharArray()); 
                }
                else if (_deviceState == HC6State.HC6Baud)
                {
                    // Update baud rate of the bluetooth module.
                    e.Result = sendAtCommand(("AT+BAUD" + (_devBaudRate + 1).ToString("X")).ToCharArray());
                }
                else if (_deviceState == HC6State.HC6Parity)
                {
                    // Update parity check type of the module. (Available from version 1.5).
                    string parityCode = "PN";
                    if (_devParity > 0)
                    {
                        parityCode = (_devParity == 1) ? "PO" : "PE";
                    }

                    e.Result = sendAtCommand(("AT+" + parityCode).ToCharArray());
                }
            }
            else
            {
                // Return port closed status in thread results.
                e.Result = HC6Error.HC6ErrorPortClosed;
                _deviceState = HC6State.HC6Idle;
            }
        }

        private void bwDevUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Check for any error result. If error detected cancel device update process and return.
            if (((HC6Error)(e.Result)) != HC6Error.HC6Success)
            {
                _deviceState = HC6State.HC6Idle;

                this.Invoke((MethodInvoker)delegate
                {
                    btnDevUpdate.Enabled = true;

                    txtStatus.Text = "Bluetooth module update failed.";
                    MessageBox.Show("Bluetooth module configuration update failed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Cancel any pending async tasks.
            if (bwDevInfo.IsBusy)
            {
                bwDevInfo.CancelAsync();
            }

            if (bwDevUpdate.IsBusy)
            {
                bwDevUpdate.CancelAsync();
            }

            // Check status of the serial port object.
            if (_serialPort != null)
            {
                // Close and dispose serial port object.
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                _serialPort.DataReceived -= _serialPort_DataReceived;
                _serialPort.Dispose();
                _serialPort = null;
            }

            // Reset UI controls to default status.
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            grpBluetooth.Enabled = false;

            txtStatus.Text = string.Empty;
            txtVersion.Text = string.Empty;
        }        
    }
}
