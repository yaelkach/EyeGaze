using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyeGaze.SpeechToText
{
    public delegate void TriggerHandler(object sender, MessageEvent message);
    public class MessageEvent : EventArgs
    {
        public string triggerWord { get; set; }
        public string[] content { get; set; }

    }
}
