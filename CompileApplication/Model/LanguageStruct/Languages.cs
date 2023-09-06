using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.Tools;

namespace CompileApplication.Model.LanguageStruct
{
    public class Languages
    {
        public List<string> LanguageNames { get; }

        private int CurrentLanguageIndex;

        public Language CurrentLanguage { get; private set; }

        private LanguageData LanguageElementData;

        public Languages()
        {
            LanguageElementData = new LanguageData();
            LanguageNames = LanguageElementData.LanguageList();
            SetCurrentLanguageIndex(0);
        }

        public int GetCurrentLanguageIndex()
        {
            return CurrentLanguageIndex;
        }

        public void SetCurrentLanguageIndex(int value)
        {
            if (LanguageNames.Count > 0)
            {
                CurrentLanguage =
                    new Language(LanguageNames[value], LanguageElementData);
            }
            else
            {
                CurrentLanguage = null;
            }
            CurrentLanguageIndex = value;
        }

        public bool AddLanguage(string addLanguage)
        {
            bool isSearchLanguage = LanguageElementData.SearchLanguage(addLanguage);
            if (!isSearchLanguage)
            {
                LanguageElementData.AddLanguage(addLanguage);
                LanguageNames.Add(addLanguage);
                SetCurrentLanguageIndex(LanguageNames.Count - 1);
                CurrentLanguage.AddLanguageVersion("Общая версия");
            }
            return !isSearchLanguage;
        }

        public bool DeleteCurrentLanguage()
        {
            bool deleteLanguagePredicate = LanguageNames.Count > 0;
            if (deleteLanguagePredicate)
            {
                LanguageElementData.DeleteLanguage(CurrentLanguage.LanguageName);
                LanguageNames.Remove(CurrentLanguage.LanguageName);
                SetCurrentLanguageIndex(0);
            }
            return deleteLanguagePredicate;
        }
    }
}