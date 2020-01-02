using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Drawing;
using System.Windows;
using Application = Microsoft.Office.Interop.Word.Application;

namespace EyeGaze.TextEditor
{
    class WordTextEditor
    {
        private int count = 0;
        List<KeyValuePair<System.Drawing.Point, string>> coordinatesWithWords;
        public Application application;
        Microsoft.Office.Interop.Word.Find fnd;

        public WordTextEditor()
        {
            application = new Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Open(@"C:\Users\tomer\Desktop\Yael\Test\Test1.docx");
            fnd = application.ActiveWindow.Selection.Find;
        }

        public void setSortedValues(List<KeyValuePair<System.Drawing.Point, string>> coordinatesWithWords)
        {
            this.coordinatesWithWords = coordinatesWithWords;

        }
        public void openWord()
        {
          
           /* //write to document
            Microsoft.Office.Interop.Word.Range rng = document.Application.ActiveDocument.Range(0, 0);
            rng.Text = "New Text";

            //replace text
            Console.Write("Replace text in document");
            Console.ReadLine();
            Microsoft.Office.Interop.Word.Range rng2 = document.Application.ActiveDocument.Range(0, 8);
            rng2.Text = "Replace";

            //copy text and paste
            Console.Write("copy and paste");
            Console.ReadLine();
            Microsoft.Office.Interop.Word.Range rng3 = document.Application.ActiveDocument.Range(0, 8);
            rng3.Copy();
            Microsoft.Office.Interop.Word.Range rng4 = document.Application.ActiveDocument.Range(8);
            rng4.Paste();
            rng3.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdGreen;

            var language = document.Application.Languages[WdLanguageID.wdEnglishUS];
            const string custDict = "custom.dic";


            Console.ReadLine();
            object optional = Missing.Value;
            rng.Text = "Helo Worlld ";
            */
            /*document.Application.ActiveDocument.CheckSpelling();

            var suggestions = document.Application.GetSpellingSuggestions(custDict, MainDictionary: language.Name);
            foreach (SpellingSuggestion spellingSuggestion in suggestions)
                MessageBox.Show("Suggested replacement: "+ spellingSuggestion.Name);
            */
           // Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = true };
            if (count == 0)
            {
                fnd.Text = "tim";
                fnd.Replacement.Text = "time";
                fnd.Execute(Replace: WdReplace.wdReplaceAll);
                count++;
            }
            else
            {
                fnd.Text = "caughtt";
                fnd.Replacement.Text = "caught";
                fnd.Execute(Replace: WdReplace.wdReplaceAll);
            }
            int x = 1;
            Console.Write(x);
        }
    }
}
