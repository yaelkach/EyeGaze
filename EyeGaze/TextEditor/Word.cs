using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Reflection;


namespace EyeGaze.TextEditor
{
    class Word
    {
        public Word()
        {

        }

        public void openWord()
        {
            Application application = new Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Open(@"C:\Users\tomer\Desktop\Yael\Test\Test.docx");

        }
        public void replaceError()
        {
            /* var ipy = Python.CreateRuntime();
         dynamic test = ipy.UseFile("Test.py");
         test.Simple();*/
            Console.Write("Write to document");
            Console.ReadLine();
            Application application = new Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Open(@"C:\Users\tomer\Desktop\Yael\Test\Test.docx");

            //write to document
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
            document.Application.ActiveDocument.CheckSpelling();

            var suggestions = document.Application.GetSpellingSuggestions(custDict, MainDictionary: language.Name);
            foreach (SpellingSuggestion spellingSuggestion in suggestions)
                Console.WriteLine("Suggested replacement: {0}", spellingSuggestion.Name);
            int x = 1;
            Console.Write(x);
        }
    }
}
