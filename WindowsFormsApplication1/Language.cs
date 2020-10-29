using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Language
    {   
        private int ID;
        private string language;
        private static List<Language> langList = new List<Language>();

        public Language() { }
        public Language(string language) 
        { 
            this.language = language; 
        }
        public Language(int id, string lang) 
        { 
            ID = id;
            language = lang;
        }

        public void SetID(int id) { ID = id; }
        public int GetID() { return ID; }

        public void SetLanguage(string language) { this.language = language; }
        public string GetLanguage() { return language; }

        public static void AddLanguageToList(Language language)
        {
            langList.Add(language);
        }
        public static List<Language> GetLanguageList() 
        { return langList; }
    } 
}
