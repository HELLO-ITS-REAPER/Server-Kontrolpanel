using System;

namespace Server_Kontrolpanel
{
    internal class SshClient
    {
        private string v1;
        private string v2;
        private string v3;

        public SshClient(string v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public bool IsConnected { get; internal set; }

        internal void Connect()
        {
            throw new NotImplementedException();
        }
    }
}