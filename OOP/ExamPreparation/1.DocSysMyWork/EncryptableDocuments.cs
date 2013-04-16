using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class EncryptableDocuments : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted
        {
            get { throw new NotImplementedException(); }
        }

        public void Encrypt()
        {
            throw new NotImplementedException();
        }

        public void Decrypt()
        {
            throw new NotImplementedException();
        }

      
    }

