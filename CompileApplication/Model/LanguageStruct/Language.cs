using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.DeterministicTableElements;
using CompileApplication.Model.SyntaxActionTypes;
using CompileApplication.Model.Tools;

namespace CompileApplication.Model.LanguageStruct
{
    public class Language
    {
        public string LanguageName { get; }

        public List<string> VersionNames { get; }

        private int CurrentVersionIndex;

        public Version CurrentVersion { get; private set; }

        private LanguageData LanguageElementData;
        
        public Language(string language, LanguageData languageData)
        {
            LanguageName = language;
            LanguageElementData = languageData;
            VersionNames = LanguageElementData.LanguageVersionList(language);
            SetCurrentVersionIndex(0);
        }

        public int GetCurrentVersionIndex()
        {
            return CurrentVersionIndex;
        }

        public void SetCurrentVersionIndex(int value)
        {
            if (VersionNames.Count > 0)
            {
                CurrentVersion = LanguageElementData.LanguageVersion(LanguageName,
                    VersionNames[value]);
            }
            else
            {
                CurrentVersion = null;
            }
            CurrentVersionIndex = value;
        }

        public bool AddLanguageVersion(string addVersion)
        {
            bool isSearchVersion = LanguageElementData.SearchLanguageVersion(LanguageName, addVersion);
            if (!isSearchVersion)
            {
                LanguageElementData.AddLanguageVersion(LanguageName, addVersion);
                VersionNames.Add(addVersion);
                SetCurrentVersionIndex(VersionNames.Count - 1);
            }
            return !isSearchVersion;
        }

        public bool AddCurrentVersionSeparator(Separator addSeparator)
        {
            bool isSearchSeparator = SearchCurrentVersionSeparator(addSeparator);
            if (!isSearchSeparator)
            {
                LanguageElementData.AddLanguageVersionSeparator(LanguageName,
                    CurrentVersion.VersionName, addSeparator);
                CurrentVersion.Separators.AddNewElement(addSeparator);
            }
            return !isSearchSeparator;
        }

        public bool AddCurrentVersionKeyword(Keyword addKeyword)
        {
            bool isSearchKeyword = SearchCurrentVersionKeyword(addKeyword);
            if (!isSearchKeyword)
            {
                LanguageElementData.AddLanguageVersionKeyword(LanguageName,
                    CurrentVersion.VersionName, addKeyword);
                CurrentVersion.Keywords.AddNewElement(addKeyword);
            }
            return !isSearchKeyword;
        }

        public bool AddCurrentVersionComment(Comment addComment)
        {
            bool isSearchComment = SearchCurrentVersionComment(addComment);
            if (!isSearchComment)
            {
                LanguageElementData.AddLanguageVersionComment(LanguageName,
                    CurrentVersion.VersionName, addComment);
                CurrentVersion.Comments.AddNewElement(addComment);
            }
            return !isSearchComment;
        }

        public bool AddCurrentVersionOtherLexem(OtherLexem addOtherLexem)
        {
            bool isSearchOtherLexem = SearchCurrentVersionOtherLexem(addOtherLexem);
            if (!isSearchOtherLexem)
            {
                LanguageElementData.AddLanguageVersionOtherLexem(LanguageName,
                    CurrentVersion.VersionName, addOtherLexem);
                CurrentVersion.OtherLexems.AddNewElement(addOtherLexem);
            }
            return !isSearchOtherLexem;
        }

        public void AddCurrentVersionSyntaxState()
        {
            LanguageElementData.AddLanguageVersionSyntaxState(LanguageName,
                CurrentVersion.VersionName);
            CurrentVersion.AddSyntaxState();
        }

        public void AddCurrentSyntaxStateElement(DeterministicElement addStateElement)
        {
            LanguageElementData.AddLanguageVersionStateElement(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1);
            CurrentVersion.GetCurrentSyntaxState().AddStateElement();
            foreach (Lexem stackLexem in addStateElement.Stack.ToList())
            {
                AddCurrentStateElementStackLexem(stackLexem);
            }
            UpdateCurrentStateElementEnterLexem(addStateElement.EnterLexem);
            foreach (IAction action in addStateElement.Actions.ToList())
            {
                AddCurrentStateElementSyntaxAction(action);
            }
        }

        public void AddCurrentStateElementStackLexem(Lexem addStackLexem)
        {
            LanguageElementData.AddLanguageVersionStackLexem(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1, 
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1, addStackLexem);
            CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().AddStackLexem(addStackLexem);
        }

        public bool AddCurrentStateElementSyntaxAction(IAction addAction)
        {
            bool isSearchAction = SearchCurrentStateElementSyntaxAction(addAction);
            if (!isSearchAction)
            {
                LanguageElementData.AddLanguageVersionSyntaxAction(LanguageName, CurrentVersion.VersionName,
                    CurrentVersion.GetCurrentSyntaxStateIndex() + 1, 
                    CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1, addAction);
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().AddAction(addAction);
            }
            return !isSearchAction;
        }

        public bool EditCurrentVersionSeparator(Separator changeSeparator)
        {
            bool isSearchSeparator = SearchCurrentVersionSeparator(changeSeparator);
            bool isThisSeparator = CurrentVersion.Separators.GetCurrentElement().Item == changeSeparator.Item;
            bool searchTerm = !isSearchSeparator || isThisSeparator;
            if (searchTerm)
            {
                LanguageElementData.EditLanguageVersionSeparator(LanguageName, CurrentVersion.VersionName,
                    CurrentVersion.Separators.GetCurrentElement(), changeSeparator);
                CurrentVersion.Separators.SetCurrentElement(changeSeparator);
            }
            return searchTerm;
        }

        public bool EditCurrentVersionKeyword(Keyword changeKeyword)
        {
            bool isSearchKeyword = SearchCurrentVersionKeyword(changeKeyword);
            bool isThisKeyword = CurrentVersion.Keywords.GetCurrentElement().Item == changeKeyword.Item;
            bool searchTerm = !isSearchKeyword || isThisKeyword;
            if (searchTerm)
            {
                LanguageElementData.EditLanguageVersionKeyword(LanguageName, CurrentVersion.VersionName,
                    CurrentVersion.Keywords.GetCurrentElement(), changeKeyword);
                CurrentVersion.Keywords.SetCurrentElement(changeKeyword);
            }
            return searchTerm;
        }

        public bool EditCurrentVersionComment(Comment changeComment)
        {
            bool isSearchComment = SearchCurrentVersionComment(changeComment);
            bool isThisComment = CurrentVersion.Comments.GetCurrentElement().Item == changeComment.Item;
            bool searchTerm = !isSearchComment || isThisComment;
            if (searchTerm)
            {
                LanguageElementData.EditLanguageVersionComment(LanguageName, CurrentVersion.VersionName,
                    CurrentVersion.Comments.GetCurrentElement(), changeComment);
                CurrentVersion.Comments.SetCurrentElement(changeComment);
            }
            return searchTerm;
        }

        public bool EditCurrentVersionOtherLexem(OtherLexem changeOtherLexem)
        {
            bool isSearchOtherLexem = SearchCurrentVersionOtherLexem(changeOtherLexem);
            bool isThisOtherLexem = CurrentVersion.OtherLexems.GetCurrentElement().Item == changeOtherLexem.Item;
            bool searchTerm = !isSearchOtherLexem || isThisOtherLexem;
            if (searchTerm)
            {
                LanguageElementData.EditLanguageVersionOtherLexem(LanguageName, CurrentVersion.VersionName,
                    CurrentVersion.OtherLexems.GetCurrentElement(), changeOtherLexem);
                CurrentVersion.OtherLexems.SetCurrentElement(changeOtherLexem);
            }
            return searchTerm;
        }

        public bool EditCurrentVersionSyntaxStatePosition(int changePosition)
        {
            bool isSearchSyntaxState = LanguageElementData.SearchLanguageVersionSyntaxState(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.GetCurrentSyntaxStateIndex() + 1);
            if (isSearchSyntaxState)
            {
                LanguageElementData.EditLanguageVersionSyntaxStatePosition(LanguageName,
                    CurrentVersion.VersionName, CurrentVersion.GetCurrentSyntaxStateIndex() + 1, changePosition + 1);
                CurrentVersion.EditCurrentSyntaxStateIndex(changePosition);
            }
            return isSearchSyntaxState;
        }

        public void EditCurrentStateElementStackLexem(Lexem changeStackLexem)
        {
            LanguageElementData.EditLanguageVersionStackLexem(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().GetCurrentStackLexemIndex() + 1,
                changeStackLexem);
            CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().SetCurrentStackLexem(changeStackLexem);
        }

        public bool EditCurrentStateElementSyntaxAction(IAction changeAction)
        {
            IAction currentAction = CurrentVersion.GetCurrentSyntaxState().
                GetCurrentStateElement().GetCurrentAction();
            bool isSearchAction = SearchCurrentStateElementSyntaxAction(changeAction);
            bool isThisAction = changeAction.EquateTo(currentAction);
            bool searchTerm = !isSearchAction || isThisAction;
            if (searchTerm)
            {
                LanguageElementData.EditLanguageVersionSyntaxAction(LanguageName, CurrentVersion.VersionName,
                    CurrentVersion.GetCurrentSyntaxStateIndex() + 1, 
                    CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1,
                    currentAction, changeAction);
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().SetCurrentAction(changeAction);
            }
            return searchTerm;
        }

        public void UpdateCurrentStateElementEnterLexem(Lexem newEnterLexem)
        {
            LanguageElementData.NewLanguageVersionEnterLexem(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1, newEnterLexem);
            CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().EnterLexem = newEnterLexem;
        }

        public bool DeleteCurrentLanguageVersion()
        {
            bool deleteVersionPredicate = CurrentVersionIndex != 0;
            if (deleteVersionPredicate)
            {
                LanguageElementData.DeleteLanguageVersion(LanguageName, CurrentVersion.VersionName);
                VersionNames.Remove(CurrentVersion.VersionName);
                SetCurrentVersionIndex(0);
            }
            return deleteVersionPredicate;
        }

        public void DeleteCurrentVersionSeparator()
        {
            LanguageElementData.DeleteLanguageVersionSeparator(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.Separators.GetCurrentElement());
            CurrentVersion.Separators.DeleteCurrentElement();
        }

        public void DeleteCurrentVersionKeyword()
        {
            LanguageElementData.DeleteLanguageVersionKeyword(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.Keywords.GetCurrentElement());
            CurrentVersion.Keywords.DeleteCurrentElement();
        }

        public void DeleteCurrentVersionComment()
        {
            LanguageElementData.DeleteLanguageVersionComment(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.Comments.GetCurrentElement());
            CurrentVersion.Comments.DeleteCurrentElement();
        }

        public void DeleteCurrentVersionOtherLexem()
        {
            LanguageElementData.DeleteLanguageVersionOtherLexem(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.OtherLexems.GetCurrentElement());
            CurrentVersion.OtherLexems.DeleteCurrentElement();
        }

        public void DeleteCurrentVersionSyntaxState()
        {
            LanguageElementData.DeleteLanguageVersionSyntaxState(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.GetCurrentSyntaxStateIndex() + 1);
            CurrentVersion.DeleteCurrentSyntaxState();
        }

        public void DeleteCurrentSyntaxStateElement()
        {
            LanguageElementData.DeleteLanguageVersionStateElement(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1);
            CurrentVersion.GetCurrentSyntaxState().DeleteCurrentStateElement();
        }

        public void DeleteCurrentStateElementStackLexem()
        {
            LanguageElementData.DeleteLanguageVersionStackLexem(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().GetCurrentStackLexemIndex() + 1);
            CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().DeleteCurrentStackLexem();
        }

        public void DeleteCurrentStateElementEnterLexem()
        {
            LanguageElementData.DeleteLanguageVersionEnterLexem(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1);
            CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().EnterLexem = null;
        }

        public void DeleteCurrentStateElementSyntaxAction()
        {
            LanguageElementData.DeleteLanguageVersionSyntaxAction(LanguageName, CurrentVersion.VersionName,
                CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().GetCurrentAction());
            CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElement().DeleteCurrentAction();
        }

        private bool SearchCurrentVersionSeparator(Separator searchSeparator)
        {
            bool isSearchSeparator;
            if (CurrentVersion.VersionName != "Общая версия")
            {
                isSearchSeparator = LanguageElementData.SearchLanguageVersionSeparator(LanguageName,
                    CurrentVersion.VersionName, searchSeparator) ||
                    LanguageElementData.SearchLanguageVersionSeparator(LanguageName,
                    "Общая версия", searchSeparator);
            }
            else
            {
                isSearchSeparator = false;
                foreach (string versionName in VersionNames)
                {
                    if (!isSearchSeparator)
                    {
                        isSearchSeparator = isSearchSeparator ||
                            LanguageElementData.SearchLanguageVersionSeparator(LanguageName,
                            versionName, searchSeparator);
                    }
                }
            }
            return isSearchSeparator;
        }

        private bool SearchCurrentVersionKeyword(Keyword searchKeyword)
        {
            bool isSearchKeyword;
            if (CurrentVersion.VersionName != "Общая версия")
            {
                isSearchKeyword = LanguageElementData.SearchLanguageVersionKeyword(LanguageName,
                    CurrentVersion.VersionName, searchKeyword) ||
                    LanguageElementData.SearchLanguageVersionKeyword(LanguageName,
                    "Общая версия", searchKeyword);
            }
            else
            {
                isSearchKeyword = false;
                foreach (string versionName in VersionNames)
                {
                    if (!isSearchKeyword)
                    {
                        isSearchKeyword = isSearchKeyword ||
                            LanguageElementData.SearchLanguageVersionKeyword(LanguageName,
                            versionName, searchKeyword);
                    }
                }
            }
            return isSearchKeyword;
        }

        private bool SearchCurrentVersionComment(Comment searchComment)
        {
            bool isSearchComment;
            if (CurrentVersion.VersionName != "Общая версия")
            {
                isSearchComment = LanguageElementData.SearchLanguageVersionComment(LanguageName,
                    CurrentVersion.VersionName, searchComment) ||
                    LanguageElementData.SearchLanguageVersionComment(LanguageName,
                    "Общая версия", searchComment);
            }
            else
            {
                isSearchComment = false;
                foreach (string versionName in VersionNames)
                {
                    if (!isSearchComment)
                    {
                        isSearchComment = isSearchComment ||
                            LanguageElementData.SearchLanguageVersionComment(LanguageName,
                            versionName, searchComment);
                    }
                }
            }
            return isSearchComment;
        }

        private bool SearchCurrentVersionOtherLexem(OtherLexem searchOtherLexem)
        {
            bool isSearchOtherLexem;
            if (CurrentVersion.VersionName != "Общая версия")
            {
                isSearchOtherLexem = LanguageElementData.SearchLanguageVersionOtherLexem(LanguageName,
                    CurrentVersion.VersionName, searchOtherLexem) ||
                    LanguageElementData.SearchLanguageVersionOtherLexem(LanguageName,
                    "Общая версия", searchOtherLexem);
            }
            else
            {
                isSearchOtherLexem = false;
                foreach (string versionName in VersionNames)
                {
                    if (!isSearchOtherLexem)
                    {
                        isSearchOtherLexem = isSearchOtherLexem ||
                            LanguageElementData.SearchLanguageVersionOtherLexem(LanguageName,
                            versionName, searchOtherLexem);
                    }
                }
            }
            return isSearchOtherLexem;
        }

        private bool SearchCurrentStateElementSyntaxAction(IAction searchAction)
        {
            bool isSearchAction;
            isSearchAction = LanguageElementData.SearchLanguageVersionSyntaxAction(LanguageName,
                CurrentVersion.VersionName, CurrentVersion.GetCurrentSyntaxStateIndex() + 1,
                CurrentVersion.GetCurrentSyntaxState().GetCurrentStateElementIndex() + 1, searchAction);
            return isSearchAction;
        }
    }
}