using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;

namespace SFTP
{
    public class SftpProtocol
    {
        private String m_strErrorDes = "";

        //SFTP client variable
        private SftpClient m_sftpClient = null;

        public SftpProtocol()
        { 
        
        }





        //Function that connects to the SFTP Server 
        public bool connectSftpServer(String strHost, int iPort, String strUserName,
            String strPassword, int iTimeout)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";

                //Creating a new instance for the SFTP client variable
                this.m_sftpClient = new SftpClient(strHost, iPort, strUserName, strPassword);
                this.m_sftpClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(iTimeout);
                this.m_sftpClient.KeepAliveInterval = TimeSpan.FromSeconds(10);

                //Connect to the server
                this.m_sftpClient.Connect();
                blResult = true;
            }
            catch (Exception exp)
            {
                //Shows return error 
                this.m_strErrorDes = "SFTP_0000: ERROR - " + exp.Message;
            }
            return blResult;
        }


        //Function -> file upload
        public bool uploadFile(String strSource, String strDesPath, bool blOverride)
        { 
            bool blResult = false;
            System.IO.FileStream fileStream = null;

            try
            {
                this.m_strErrorDes = "";

                //File stream from local directory
                fileStream = new System.IO.FileStream(strSource, 
                    System.IO.FileMode.Open,System.IO.FileAccess.Read);

                this.m_sftpClient.UploadFile(fileStream, strDesPath, blOverride, null);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0001: ERROR - " + exp.Message;
            }
            finally
            {
                //Close file stream
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return blResult;
        }


        //Function -> download file
        public bool downloadFile(String strSftpPath, String strLocalPath)
        {
            bool blResult = false;
            System.IO.FileStream fileStream = null;

            try
            {
                this.m_strErrorDes = "";
                //Open File from the local directory
                fileStream = new System.IO.FileStream(strLocalPath, System.IO.FileMode.OpenOrCreate);

                //Download file from the SFTP server
                this.m_sftpClient.DownloadFile(strSftpPath, fileStream, null);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0002: ERROR - " + exp.Message;
            }
            finally
            {
                //Close stream
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }
            return blResult;
        }


        //Function -> delete file
        public bool deleteFile(String strFilePath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.DeleteFile(strFilePath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0004: ERROR - " + exp.Message;
            }
            return blResult;
        }


        //Function -> rename file
        public bool renameFile(String strOldPathName,String strNewPathName)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.RenameFile(strOldPathName, strNewPathName);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0005: ERROR - " + exp.Message;
            }
            return blResult;
        }


        //Function -> delete folder
        public bool deleteDirectory(String strFolderPath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.DeleteDirectory(strFolderPath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0006: ERROR - " + exp.Message;
            }
            return blResult;
        }


        //Function -> create new folder
        public bool creatingDirectory(String strFolderPath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.CreateDirectory(strFolderPath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0007: ERROR - " + exp.Message;
            }
            return blResult;
        }


        //Create a text file
        public bool creatingText(String strFilePath)
        {
            bool blResult = false;

            try
            {
                this.m_strErrorDes = "";
                this.m_sftpClient.CreateText(strFilePath);
                blResult = true;
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0008: ERROR - " + exp.Message;
            }
            return blResult;
        }


        //Show a list of files found in the SFTP server
        public IEnumerable<Renci.SshNet.Sftp.SftpFile> listFile(String strSftpPath)
        {
            IEnumerable<Renci.SshNet.Sftp.SftpFile> ienFileList = null;

            try
            {
                this.m_strErrorDes = "";
                ienFileList = this.m_sftpClient.ListDirectory(strSftpPath, null);
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0003: ERROR - " + exp.Message;
            }
            return ienFileList;
        }


        //Synchronize directory files (blocking)
        public IEnumerable<System.IO.FileInfo> SyncDirectory(string sourcePath, string destinationPath, string searchPattern)
        {
             IEnumerable < System.IO.FileInfo > SyncFileInfo = null;

            try
            {
                this.m_strErrorDes = "";
                SyncFileInfo = this.m_sftpClient.SynchronizeDirectories( sourcePath,  destinationPath,  searchPattern);
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0009: ERROR - " + exp.Message;
            }
            return SyncFileInfo;
        }


        //Begin Synchronizing files (async-callback)
        public IAsyncResult BeginSyncDirectory(string sourcePath, string destinationPath, string searchPattern, AsyncCallback asyncCallback, object state)
        {
            IAsyncResult asyncResult = null;
            try
            {
                this.m_strErrorDes = "";
                asyncResult = this.m_sftpClient.BeginSynchronizeDirectories( sourcePath,  destinationPath,  searchPattern, asyncCallback, state);
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0009: ERROR - " + exp.Message;
            }
            return asyncResult;
        }


        //End synchronization (async)
        public IEnumerable<System.IO.FileInfo> EndSynchronizeDirectory(IAsyncResult asyncResult)
        {
            IEnumerable<System.IO.FileInfo> SyncFileInfo = null;

            try
            {
                this.m_strErrorDes = "";
                SyncFileInfo = this.m_sftpClient.EndSynchronizeDirectories(asyncResult);
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0009: ERROR - " + exp.Message;
            }
            return SyncFileInfo;

        }


        //Close SFTP
        public void close()
        {
            try
            {
                if (this.m_sftpClient != null)
                {
                    this.m_sftpClient.Disconnect();
                }
            }
            catch (Exception exp)
            {
                this.m_strErrorDes = "SFTP_0010: ERROR - " + exp.Message;
            }
            this.m_sftpClient = null;
        }


        //Get error
        public String getErrorDes()
        {
            return this.m_strErrorDes;
        }





    }

}
