using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakiFront
{
    public class ErrorResponse : JsonClass
    {
        protected override byte _id { get { return Global.ERROR_RESPONSE; } }
        public string message { get; set; }

        public ErrorResponse()
        {

        }

        public ErrorResponse(ErrorResponse other)
        {
            message = other.message;
        }


        public ErrorResponse(string json) : this(JsonConvert.DeserializeObject<ErrorResponse>(json))
        {

        }

        public override string ToJsonFormat()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void Show()
        {
            //ErrorResponse err = buffer.GetObject<ErrorResponse>();
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
