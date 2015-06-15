using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace Tank_Platoons.App_Code
{
    class XMLValidator
    {
        public bool Validate(string inputUri)
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.DtdProcessing = DtdProcessing.Parse;
            readerSettings.ValidationType = ValidationType.DTD;
            readerSettings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);
            try
            {
                XmlReader reader = XmlReader.Create(inputUri, readerSettings);
                while (reader.Read()) { }
                reader.Close();
            }
            catch (ArgumentException ane)
            {
                this.ValidationFailed(ane.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                this.ValidationFailed(fnfe.Message);
            }
            catch (UriFormatException ufe)
            {
                this.ValidationFailed(ufe.Message);
            }
            catch (XmlException xe)
            {
                this.ValidationFailed(xe.Message);
            }
            return true;
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            this.ValidationFailed(args.Message);
        }

        private void ValidationFailed(string msg)
        {
            throw new XmlSchemaValidationException(msg);
        }
    }
}
