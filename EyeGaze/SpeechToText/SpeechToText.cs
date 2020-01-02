using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EyeGaze.SpeechToText
{
    class SpeechToText
    {
        InterfaceSpeechToText speechToText;
        public event TriggerHandler triggerHandler;
        string[] actions;

        public SpeechToText(Type speechToTextType)
        {
            speechToText = (InterfaceSpeechToText)Activator.CreateInstance(speechToTextType);
            actions = new string[] { "Fix", "Add", "Move" };
        }
        public void FindActionFromSpeech()
        {
            while (true)
            {
                string result = speechToText.listen();
                if (result != "")
                {
                    result = result.Substring(0, result.Length - 1);
                    string[] text = result.Split(' ');
                    parseResult(text);
                }

            }

        }

        public void parseResult(string[] text)
        {
            if (text.Length > 0)
            {
                if (actions.Contains(text[0]))
                {
                    if (text[0] != "Fix" && text.Length == 1)           //Move or Add without words after
                        return;
                    if (text[0] == "Add" && text.Length < 3)            // Add with less then two words after
                        return;
                    MessageEvent message = new MessageEvent();
                    message.triggerWord = text[0];
                    if (text[0] == "Fix" && text.Length > 1)
                        message.triggerWord = "Fix word";
                    if (text.Length > 0)
                    {
                        string[] content = new string[text.Length - 1];
                        Array.Copy(text, 1, content, 0, text.Length - 1);
                        message.content = content;
                    }
                    if (triggerHandler != null)
                    {
                        triggerHandler(this, message);
                    }
                }

            }
        }

    }
}
