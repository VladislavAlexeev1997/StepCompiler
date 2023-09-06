using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using CompileApplication.Model.LanguageStruct;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.SyntaxActionTypes;
using CompileApplication.Model.DeterministicTableElements;

namespace CompileApplication.Model.Tools
{
    public class LanguageData
    {
        private const string DATA_FILE_NAME = @"Data\Language.xml";

        private XDocument dataDocument;

        public LanguageData()
        {
            FileInfo dataFileInfo = new FileInfo(DATA_FILE_NAME);
            if (!dataFileInfo.Exists)
            {
                DirectoryInfo dataDirectoryInfo = new DirectoryInfo("Data");
                if(!dataDirectoryInfo.Exists)
                {
                    dataDirectoryInfo.Create();
                }
                dataDocument = new XDocument(
                    new XElement("languages"));
                dataDocument.Save(DATA_FILE_NAME);
            }
            dataDocument = XDocument.Load(DATA_FILE_NAME);
        }
        
        public List<string> LanguageList()
        {
            List<string> Languages = new List<string>();
            XElement languages = dataDocument.Element("languages");
            foreach (XElement language in languages.Elements("language"))
            {
                Languages.Add(language.Attribute("name").Value);
            }
            return Languages;
        }
        
        public List<string> LanguageVersionList(string selectLanguage)
        {
            List<string> LanguageVersions = new List<string>();
            XElement language = SelectLanguage(selectLanguage);
            if (language != null)
            {
                foreach (XElement version in language.Elements("version"))
                {
                    LanguageVersions.Add(version.Attribute("name").Value);
                }
            }
            return LanguageVersions;
        }
        
        public LanguageStruct.Version LanguageVersion(string selectLanguage, string selectVersion)
        {
            ViewerList<Separator> Separators = 
                GetLanguageVersionLexems<Separator>(selectLanguage, selectVersion, "separators", "separator");
            ViewerList<Keyword> Keywords =
                GetLanguageVersionLexems<Keyword>(selectLanguage, selectVersion, "keywords", "keyword");
            ViewerList<Comment> Comments =
                GetLanguageVersionLexems<Comment>(selectLanguage, selectVersion, "comments", "comment");
            ViewerList<OtherLexem> OtherLexems =
                GetLanguageVersionLexems<OtherLexem>(selectLanguage, selectVersion, "otherlexems", "otherlexem");
            Identificator identificator = 
                ConvertXElementToLexem<Identificator>(SelectLanguageIdentificator(selectLanguage), false);
            Number number = 
                ConvertXElementToLexem<Number>(SelectLanguageNumber(selectLanguage), false);
            Literal literal =
                ConvertXElementToLexem<Literal>(SelectLanguageLiteral(selectLanguage), false);
            ViewerList<DeterministicState> SyntaxTable =
                GetLanguageVersionSyntaxTable(selectLanguage, selectVersion);
            return new LanguageStruct.Version(selectVersion, Separators, Keywords, Comments, OtherLexems,
                identificator, number, literal, SyntaxTable);
        }

        private ViewerList<LexemType> GetLanguageVersionLexems<LexemType> (string selectLanguage, 
            string selectVersion, string lexemGroupName, string lexemTypeName)
        {
            ViewerList<LexemType> Lexems = new ViewerList<LexemType>();
            XElement version = SelectLanguageVersion(selectLanguage, selectVersion);
            if (version != null)
            {
                if (version.Attribute("name").Value != "Общая версия")
                {
                    XElement allVersion = SelectLanguageVersion(selectLanguage, "Общая версия");
                    foreach (XElement lexem in
                        allVersion.Element(lexemGroupName).Elements(lexemTypeName))
                    {
                        LexemType lexemTypeObject = ConvertXElementToLexem<LexemType>(lexem, false);
                        Lexems.AddNewElement(lexemTypeObject);
                    }
                }
                foreach (XElement lexem in
                        version.Element(lexemGroupName).Elements(lexemTypeName))
                {
                    LexemType lexemTypeObject = ConvertXElementToLexem<LexemType>(lexem, true);
                    Lexems.AddNewElement(lexemTypeObject);
                }
            }
            return Lexems;
        }

        private LexemType ConvertXElementToLexem<LexemType>(XElement xElement, bool isEdit)
        {
            Type lexemType = typeof(LexemType);
            string typeName = typeof(LexemType).Name;
            object[] lexemParameters;
            switch(typeName)
            {
                case "Keyword":
                case "Comment":
                case "Separator":
                    lexemParameters = new object[] { xElement.Element("item").Value,
                        xElement.Element("commenting").Value, isEdit };
                    break;
                default:
                    lexemParameters = new object[] { xElement.Value, isEdit };
                    break;
            }
            object lexemObject = Activator.CreateInstance(lexemType, lexemParameters);
            return (LexemType)lexemObject;
        }

        private ViewerList<DeterministicState> GetLanguageVersionSyntaxTable(
            string selectLanguage, string selectVersion)
        {
            ViewerList<DeterministicState> SyntaxTable = new ViewerList<DeterministicState>();
            XElement version = SelectLanguageVersion(selectLanguage, selectVersion);
            if (version != null)
            {
                int copyStateIndex = 0;
                foreach(XElement xState in version.Element("syntaxtable").Elements("state"))
                {
                    DeterministicState state = new DeterministicState();
                    if (xState.Attribute("pertain").Value == "copy")
                    {
                        copyStateIndex++;
                    }
                    int copyElementIndex = 0;
                    foreach (XElement xElement in xState.Elements("row"))
                    {
                        XElement xStateElement;
                        DeterministicElement stateElement;
                        if (xElement.Attribute("pertain").Value == "copy")
                        {
                            copyElementIndex++;
                            xStateElement = SelectLanguageVersionStateElement(selectLanguage, 
                                "Общая версия", copyStateIndex, copyElementIndex, "original");
                            stateElement = GetLanguageVersionStateRow(false, xStateElement);
                        }
                        else
                        {
                            stateElement = GetLanguageVersionStateRow(true, xElement);
                        }
                        state.StateElements.AddNewElement(stateElement);
                    }
                    SyntaxTable.AddNewElement(state);
                }
            }
            return SyntaxTable;
        }

        private DeterministicElement GetLanguageVersionStateRow(bool isEdit, XElement xStateElement)
        {
            DeterministicElement stateElement = new DeterministicElement();
            stateElement.IsEdit = isEdit;
            foreach (XElement stackLexem in xStateElement.Element("stack").Elements("stacklexem"))
            {
                stateElement.AddStackLexem(new Lexem(stackLexem.Value));
            }
            stateElement.EnterLexem = new Lexem(xStateElement.Element("enterlexem").Value);
            foreach (XElement action in xStateElement.Element("actions").Elements("action"))
            {
                switch (action.Attribute("name").Value)
                {
                    case "shift":
                        stateElement.AddAction(new ShiftAction());
                        break;
                    case "passing":
                        stateElement.AddAction(new PassingAction(
                            int.Parse(action.Element("tostate").Value)));
                        break;
                    case "from":
                        stateElement.AddAction(new FromAction(
                            int.Parse(action.Element("lexemcount").Value),
                            new Lexem(action.Element("tolexem").Value)));
                        break;
                    case "end":
                        stateElement.AddAction(new EndAction());
                        break;
                }
            }
            return stateElement;
        }

        public void AddLanguage(string addLanguage)
        {
            XElement languages = dataDocument.Element("languages");
            languages.Add(new XElement("language",
                new XAttribute("name", addLanguage),
                new XElement("identificator", "<идент>"), 
                new XElement("number", "<число>"), 
                new XElement("literal", "<литерал>")));
            dataDocument.Save(DATA_FILE_NAME);
            AddLanguageVersion(addLanguage, "Общая версия");
        }
        
        public void AddLanguageVersion(string selectLanguage, string addVersion)
        {
            XElement language = SelectLanguage(selectLanguage);
            if (language != null)
            {
                language.Add(new XElement("version", new XAttribute("name", addVersion),
                    new XElement("separators"), new XElement("keywords"),
                    new XElement("comments"), new XElement("otherlexems"),
                    new XElement("syntaxtable")));
                dataDocument.Save(DATA_FILE_NAME);
                if (addVersion == "Общая версия")
                {
                    AddLanguageVersionOtherLexem(selectLanguage, addVersion, new OtherLexem("S"));
                    AddLanguageVersionOtherLexem(selectLanguage, addVersion, new OtherLexem("ε"));
                    AddLanguageVersionSyntaxState(selectLanguage, addVersion);
                    AddLanguageVersionStateElement(selectLanguage, addVersion, 1);
                    AddLanguageVersionStackLexem(selectLanguage, addVersion, 1, 1, new Lexem("S"));
                    AddLanguageVersionSyntaxAction(selectLanguage, addVersion, 1, 1, new EndAction());
                    AddLanguageVersionStateElement(selectLanguage, addVersion, 1);
                    AddLanguageVersionStackLexem(selectLanguage, addVersion, 1, 2, new Lexem("ε"));
                    AddLanguageVersionSyntaxAction(selectLanguage, addVersion, 1, 2, new ShiftAction());
                }
                else
                {
                    XElement allVersionSyntaxTable = 
                        SelectLanguageVersionSyntaxTable(selectLanguage, "Общая версия");
                    int nowSyntaxElementNumber = 1;
                    foreach(XElement syntaxState in allVersionSyntaxTable.Elements("state"))
                    {
                        AddLanguageVersionSyntaxStateWithOriginal(selectLanguage, addVersion, "copy");
                        foreach(XElement syntaxElement in syntaxState.Elements("row"))
                        {
                            AddLanguageVersionStateElementWithOriginal(selectLanguage, addVersion,
                                nowSyntaxElementNumber, "copy");
                        }
                        nowSyntaxElementNumber++;
                    }
                }
            }
        }
        
        public void AddLanguageVersionSeparator(string selectLanguage,
            string selectVersion, Separator addSeparator)
        {
            AddLanguageVersionLexemWithComment(selectLanguage, selectVersion,
                "separators", "separator", addSeparator.Item, addSeparator.Commentary);
        }
        
        public void AddLanguageVersionKeyword(string selectLanguage,
            string selectVersion, Keyword addKeyword)
        {
            AddLanguageVersionLexemWithComment(selectLanguage, selectVersion,
                "keywords", "keyword", addKeyword.Item, addKeyword.Commentary);
        }
        
        public void AddLanguageVersionComment(string selectLanguage,
            string selectVersion, Comment addComment)
        {
            AddLanguageVersionLexemWithComment(selectLanguage, selectVersion,
                "comments", "comment", addComment.Item, addComment.Commentary);
        }

        public void AddLanguageVersionOtherLexem(string selectLanguage,
            string selectVersion, OtherLexem addOtherLexem)
        {
            XElement version = SelectLanguageVersion(selectLanguage, selectVersion);
            AddLanguageVersionLexemWithoutComment(version, "otherlexems",
                "otherlexem", addOtherLexem);
        }

        public void AddLanguageVersionSyntaxState(string selectLanguage,
            string selectVersion)
        {
            AddLanguageVersionSyntaxStateWithOriginal(selectLanguage,
                selectVersion, "original");
            if (selectVersion == "Общая версия")
            {
                foreach (string version in LanguageVersionList(selectLanguage))
                {
                    if (version != "Общая версия")
                    {
                        AddLanguageVersionSyntaxStateWithOriginal(selectLanguage,
                            version, "copy");
                    }
                }
            }
        }

        private void AddLanguageVersionSyntaxStateWithOriginal(string selectLanguage,
            string selectVersion, string originalNode)
        {
            XElement syntaxTable =
                SelectLanguageVersionSyntaxTable(selectLanguage, selectVersion);
            AddLanguageVersionSyntaxElement(syntaxTable,
                new XElement("state", new XAttribute("pertain", originalNode)), originalNode);
        }

        public void AddLanguageVersionStateElement(string selectLanguage,
            string selectVersion, int selectStateNumber)
        {
            AddLanguageVersionStateElementWithOriginal(selectLanguage,
                selectVersion, selectStateNumber, "original");
            if (selectVersion == "Общая версия")
            {
                foreach (string version in LanguageVersionList(selectLanguage))
                {
                    if (version != "Общая версия")
                    {
                        AddLanguageVersionStateElementWithOriginal(selectLanguage,
                            version, selectStateNumber, "copy");
                    }
                }
            }
        }

        private void AddLanguageVersionStateElementWithOriginal(string selectLanguage,
            string selectVersion, int selectStateNumber, string originalNode)
        {
            XElement state = SelectLanguageVersionSyntaxState(selectLanguage,
                selectVersion, selectStateNumber, "original");
            if (originalNode == "original")
            {
                AddLanguageVersionSyntaxElement(state, new XElement("row",
                    new XAttribute("pertain", originalNode), new XElement("stack"),
                    new XElement("enterlexem"), new XElement("actions")), originalNode);
            }
            else
            {
                AddLanguageVersionSyntaxElement(state, new XElement("row",
                    new XAttribute("pertain", originalNode)), originalNode);
            }
        }

        public void AddLanguageVersionStackLexem(string selectLanguage,
            string selectVersion, int selectStateNumber,
            int selectElementNumber, Lexem addStackLexem)
        {
            XElement stateElement = SelectLanguageVersionStateElement(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, "original");
            AddLanguageVersionLexemWithoutComment(stateElement, "stack",
                "stacklexem", addStackLexem);
        }

        public void AddLanguageVersionSyntaxAction(string selectLanguage,
            string selectVersion, int selectStateNumber,
            int selectElementNumber, IAction addAction)
        {
            XElement stateElement = SelectLanguageVersionStateElement(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, "original");
            if (stateElement != null)
            {
                XElement actions = stateElement.Element("actions");
                switch(addAction.Type())
                {
                    case ActionType.Shift:
                        actions.Add(new XElement("action", new XAttribute("name", "shift")));
                        break;
                    case ActionType.Passing:
                        actions.Add(new XElement("action", new XAttribute("name", "passing"),
                            new XElement("tostate", ((PassingAction)addAction).ToState.ToString())));
                        break;
                    case ActionType.From:
                        actions.Add(new XElement("action", new XAttribute("name", "from"),
                            new XElement("lexemcount", ((FromAction)addAction).FromLexemCount.ToString()),
                            new XElement("tolexem", ((FromAction)addAction).ToLexem.Item)));
                        break;
                    case ActionType.End:
                        actions.Add(new XElement("action", new XAttribute("name", "end")));
                        break;
                }
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        private void AddLanguageVersionLexemWithComment(string selectLanguage,
            string selectVersion, string groupNodeName, string addLexemNodeName,
            string addLexemItem, string addLexemComment)
        {
            XElement version = SelectLanguageVersion(selectLanguage, selectVersion);
            if (version != null)
            {
                XElement lexemGroup = version.Element(groupNodeName);
                lexemGroup.Add(new XElement(addLexemNodeName,
                    new XElement("item", addLexemItem),
                    new XElement("commenting", addLexemComment)));
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        private void AddLanguageVersionLexemWithoutComment(XElement pregroupNode,
            string groupNodeName, string addLexemNodeName, Lexem addLexem)
        {
            if (pregroupNode != null)
            {
                XElement lexemGroup = pregroupNode.Element(groupNodeName);
                lexemGroup.Add(new XElement(addLexemNodeName, addLexem.Item));
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        private void AddLanguageVersionSyntaxElement(XElement groupNode,
            XElement addNode, string originalNode)
        {
            if (groupNode != null)
            {
                XElement lastElement;
                try
                {
                    lastElement = groupNode.Elements().Last(
                        element => element.Attribute("pertain").Value == originalNode);
                }
                catch
                {
                    lastElement = null;
                }
                if (lastElement != null)
                {
                    lastElement.AddAfterSelf(addNode);
                }
                else if (originalNode == "copy")
                {
                    groupNode.AddFirst(addNode);
                }
                else
                {
                    groupNode.Add(addNode);
                }
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        public void EditLanguageVersionSeparator(string selectLanguage,
            string selectVersion, Separator editSeparator, Separator changeSeparator)
        {
            XElement separator = SelectLanguageVersionSeparator(selectLanguage,
                selectVersion, editSeparator);
            EditLanguageVersionLexemWithComment(separator, changeSeparator.Item,
                changeSeparator.Commentary);
        }
        
        public void EditLanguageVersionKeyword(string selectLanguage,
            string selectVersion, Keyword editKeyword, Keyword changeKeyword)
        {
            XElement keyword = SelectLanguageVersionKeyword(selectLanguage,
                selectVersion, editKeyword);
            EditLanguageVersionLexemWithComment(keyword, changeKeyword.Item,
                changeKeyword.Commentary);
        }
        
        public void EditLanguageVersionComment(string selectLanguage,
            string selectVersion, Comment editComment, Comment changeComment)
        {
            XElement comment = SelectLanguageVersionComment(selectLanguage,
                selectVersion, editComment);
            EditLanguageVersionLexemWithComment(comment, changeComment.Item,
                changeComment.Commentary);
        }

        public void EditLanguageVersionOtherLexem(string selectLanguage,
            string selectVersion, OtherLexem editOtherLexem, OtherLexem changeOtherLexem)
        {
            XElement otherLexem = SelectLanguageVersionOtherLexem(selectLanguage,
                selectVersion, editOtherLexem);
            EditLanguageVersionLexemWithoutComment(otherLexem, changeOtherLexem);
        }

        public void EditLanguageVersionSyntaxStatePosition(string selectLanguage,
            string selectVersion, int editStateNumber, int changeStateNumber)
        {
            EditLanguageVersionSyntaxStatePositionWithOriginal(selectLanguage, 
                selectVersion, editStateNumber, changeStateNumber, "original");
            if (selectVersion == "Общая версия")
            {
                foreach (string version in LanguageVersionList(selectLanguage))
                {
                    if (version != "Общая версия")
                    {
                        EditLanguageVersionSyntaxStatePositionWithOriginal(selectLanguage,
                            selectVersion, editStateNumber, changeStateNumber, "copy");
                    }
                }
            }
        }

        private void EditLanguageVersionSyntaxStatePositionWithOriginal(string selectLanguage,
            string selectVersion, int editStateNumber, int changeStateNumber, string originalName)
        {
            XElement syntaxTable =
                SelectLanguageVersionSyntaxTable(selectLanguage, selectVersion);
            if (syntaxTable != null)
            {
                XElement editState = SelectLanguageVersionSyntaxState(selectLanguage,
                    selectVersion, editStateNumber, originalName);
                if (editState != null)
                {
                    DeleteLanguageVersionSyntaxStateWithOriginal(selectLanguage,
                        selectVersion, editStateNumber, originalName);
                    bool isBeforeChangePosition = editStateNumber > changeStateNumber;
                    bool isNotEditPosition = editStateNumber == changeStateNumber;
                    if (!isNotEditPosition)
                    {
                        int stateNumber = 1;
                        if (!isBeforeChangePosition)
                        {
                            changeStateNumber--;
                        }
                        foreach (XElement state in syntaxTable.Elements("state"))
                        {
                            bool isSearch = false;
                            if (originalName == "copy")
                            {
                                isSearch = state.Attribute("pertain").Value == "copy";
                            }
                            else
                            {
                                isSearch = true;
                            }
                            if (isSearch)
                            {
                                if (stateNumber == changeStateNumber)
                                {
                                    if (isBeforeChangePosition)
                                    {
                                        state.AddBeforeSelf(editState);
                                    }
                                    else
                                    {
                                        state.AddAfterSelf(editState);
                                    }
                                    break;
                                }
                                stateNumber++;
                            }
                        }
                        dataDocument.Save(DATA_FILE_NAME);
                    }
                }
            }
        }

        public void EditLanguageVersionStackLexem(string selectLanguage,
            string selectVersion, int selectStateNumber, int selectElementNumber,
            int editStackLexemNumber, Lexem changeStackLexem)
        {
            XElement stackLexem = SelectLanguageVersionStackLexem(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, editStackLexemNumber);
            EditLanguageVersionLexemWithoutComment(stackLexem, changeStackLexem);
        }

        public void EditLanguageVersionSyntaxAction(string selectLanguage,
            string selectVersion, int selectStateNumber, int selectElementNumber,
            IAction editAction, IAction changeAction)
        {
            XElement action = SelectLanguageVersionSyntaxAction(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, editAction);
            if (action != null)
            {
                action.RemoveNodes();
                switch (changeAction.Type())
                {
                    case ActionType.Shift:
                        action.Attribute("name").Value = "shift";
                        break;
                    case ActionType.Passing:
                        action.Attribute("name").Value = "passing";
                        action.Add(new XElement("tostate", ((PassingAction)changeAction).ToState.ToString()));
                        break;
                    case ActionType.From:
                        action.Attribute("name").Value = "from";
                        action.Add(new XElement("lexemcount", ((FromAction)changeAction).FromLexemCount.ToString()),
                            new XElement("tolexem", ((FromAction)changeAction).ToLexem.Item));
                        break;
                    case ActionType.End:
                        action.Attribute("name").Value = "end";
                        break;
                }
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        private void EditLanguageVersionLexemWithComment(XElement editLexemNode,
            string changeLexemItem, string changeLexemComment)
        {
            if (editLexemNode != null)
            {
                editLexemNode.Element("item").Value = changeLexemItem;
                editLexemNode.Element("commenting").Value = changeLexemComment;
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        private void EditLanguageVersionLexemWithoutComment(XElement editLexemNode,
            Lexem changeLexem)
        {
            if (editLexemNode != null)
            {
                editLexemNode.Value = changeLexem.Item;
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        public void DeleteLanguage(string deleteLanguage)
        {
            XElement language = SelectLanguage(deleteLanguage);
            DeleteXMLElement(language, "Remove");
        }
        
        public void DeleteLanguageVersion(string selectLanguage, string deleteVersion)
        {
            XElement version = SelectLanguageVersion(selectLanguage, deleteVersion);
            DeleteXMLElement(version, "Remove");
        }
        
        public void DeleteLanguageVersionSeparator(string selectLanguage,
            string selectVersion, Separator deleteSeparator)
        {
            XElement separator = SelectLanguageVersionSeparator(selectLanguage,
                selectVersion, deleteSeparator);
            DeleteXMLElement(separator, "Remove");
        }
        
        public void DeleteLanguageVersionKeyword(string selectLanguage,
            string selectVersion, Keyword deleteKeyword)
        {
            XElement keyword = SelectLanguageVersionKeyword(selectLanguage,
                selectVersion, deleteKeyword);
            DeleteXMLElement(keyword, "Remove");
        }
        
        public void DeleteLanguageVersionComment(string selectLanguage,
            string selectVersion, Comment deleteComment)
        {
            XElement comment = SelectLanguageVersionComment(selectLanguage,
                selectVersion, deleteComment);
            DeleteXMLElement(comment, "Remove");
        }

        public void DeleteLanguageVersionOtherLexem(string selectLanguage,
            string selectVersion, OtherLexem deleteOtherLexem)
        {
            XElement otherLexem = SelectLanguageVersionOtherLexem(selectLanguage,
                selectVersion, deleteOtherLexem);
            DeleteXMLElement(otherLexem, "Remove");
        }

        public void DeleteLanguageVersionSyntaxState(string selectLanguage,
            string selectVersion, int deleteStateNumber)
        {
            DeleteLanguageVersionSyntaxStateWithOriginal(selectLanguage,
                selectVersion, deleteStateNumber, "original");
            if (selectVersion == "Общая версия")
            {
                foreach (string version in LanguageVersionList(selectLanguage))
                {
                    if (version != "Общая версия")
                    {
                        DeleteLanguageVersionSyntaxStateWithOriginal(selectLanguage,
                            version, deleteStateNumber, "copy");
                    }
                }
            }
        }

        private void DeleteLanguageVersionSyntaxStateWithOriginal(string selectLanguage,
            string selectVersion, int deleteStateNumber, string originalNode)
        {
            XElement deleteState = SelectLanguageVersionSyntaxState(selectLanguage,
                selectVersion, deleteStateNumber, originalNode);
            DeleteXMLElement(deleteState, "Remove");
        }

        public void DeleteLanguageVersionStateElement(string selectLanguage,
            string selectVersion, int selectStateNumber, int deleteElementNumber)
        {
            DeleteLanguageVersionStateElementWithOriginal(selectLanguage,
                selectVersion, selectStateNumber, deleteElementNumber, "original");
            if (selectVersion == "Общая версия")
            {
                foreach (string version in LanguageVersionList(selectLanguage))
                {
                    if (version != "Общая версия")
                    {
                        DeleteLanguageVersionStateElementWithOriginal(selectLanguage,
                            version, selectStateNumber, deleteElementNumber, "copy");
                    }
                }
            }
        }

        private void DeleteLanguageVersionStateElementWithOriginal(string selectLanguage,
            string selectVersion, int selectStateNumber,
            int deleteElementNumber, string originalNode)
        {
            XElement deleteElement = SelectLanguageVersionStateElement(selectLanguage,
                selectVersion, selectStateNumber, deleteElementNumber, originalNode);
            DeleteXMLElement(deleteElement, "Remove");
        }

        public void DeleteLanguageVersionStackLexem(string selectLanguage,
            string selectVersion, int selectStateNumber, 
            int selectElementNumber, int deleteStackLexemNumber)
        {
            XElement deleteStackLexem = SelectLanguageVersionStackLexem(selectLanguage, 
                selectVersion, selectStateNumber, selectElementNumber, deleteStackLexemNumber);
            DeleteXMLElement(deleteStackLexem, "Remove");
        }

        public void DeleteLanguageVersionEnterLexem(string selectLanguage,
            string selectVersion, int selectStateNumber, int selectElementNumber)
        {
            XElement enterLexem = SelectLanguageVersionEnterLexem(selectLanguage, 
                selectVersion, selectStateNumber, selectElementNumber);
            DeleteXMLElement(enterLexem, "Remove all");
        }

        public void DeleteLanguageVersionSyntaxAction(string selectLanguage,
            string selectVersion, int selectStateNumber, 
            int selectElementNumber, IAction deleteAction)
        {
            XElement action = SelectLanguageVersionSyntaxAction(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, deleteAction);
            DeleteXMLElement(action, "Remove");
        }

        private void DeleteXMLElement(XElement deleteElement, string deleteType)
        {
            if (deleteElement != null)
            {
                switch (deleteType)
                {
                    case "Remove":
                        deleteElement.Remove();
                        break;
                    case "Remove all":
                        deleteElement.RemoveAll();
                        break;
                }
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        public bool IsLanguageVersionEnterLexem(string selectLanguage,
            string selectVersion, int selectStateNumber, int selectElementNumber)
        {
            XElement enterLexem = SelectLanguageVersionEnterLexem(selectLanguage, 
                selectVersion, selectStateNumber, selectElementNumber);
            bool isEnterLexem = enterLexem != null;
            if (isEnterLexem)
            {
                isEnterLexem = isEnterLexem && enterLexem.Value != "";
            }
            return isEnterLexem;
        }
        
        public void NewLanguageVersionEnterLexem(string selectLanguage,
            string selectVersion, int selectStateNumber,
            int selectElementNumber, Lexem newEnterLexem)
        {
            XElement enterLexemNode = SelectLanguageVersionEnterLexem(selectLanguage, 
                selectVersion, selectStateNumber, selectElementNumber);
            if (enterLexemNode != null)
            {
                enterLexemNode.Value = newEnterLexem.Item;
                dataDocument.Save(DATA_FILE_NAME);
            }
        }

        public bool SearchLanguage(string searchLanguage)
        {
            return SelectLanguage(searchLanguage) != null;
        }
        
        public bool SearchLanguageVersion(string selectLanguage, string searchVersion)
        {
            return SelectLanguageVersion(selectLanguage, searchVersion) != null;
        }
        
        public bool SearchLanguageVersionSeparator(string selectLanguage,
            string selectVersion, Separator searchSeparator)
        {
            return SelectLanguageVersionSeparator(selectLanguage, selectVersion,
                searchSeparator) != null;
        }
        
        public bool SearchLanguageVersionKeyword(string selectLanguage,
            string selectVersion, Keyword searchKeyword)
        {
            return SelectLanguageVersionKeyword(selectLanguage, selectVersion,
                searchKeyword) != null;
        }
        
        public bool SearchLanguageVersionComment(string selectLanguage,
            string selectVersion, Comment searchComment)
        {
            return SelectLanguageVersionComment(selectLanguage, selectVersion,
                searchComment) != null;
        }

        public bool SearchLanguageVersionOtherLexem(string selectLanguage,
            string selectVersion, OtherLexem searchOtherLexem)
        {
            return SelectLanguageVersionOtherLexem(selectLanguage, selectVersion,
                searchOtherLexem) != null;
        }

        public bool SearchLanguageVersionSyntaxState(string selectLanguage,
            string selectVersion, int searchStateNumber)
        {
            return SelectLanguageVersionSyntaxState(selectLanguage, selectVersion,
                searchStateNumber, "original") != null;
        }

        public bool SearchLanguageVersionStateElement(string selectLanguage,
            string selectVersion, int selectStateNumber, int searchElementNumber)
        {
            return SelectLanguageVersionStateElement(selectLanguage, selectVersion,
                selectStateNumber, searchElementNumber, "original") != null;
        }

        public bool SearchLanguageVersionStackLexem(string selectLanguage,
           string selectVersion, int selectStateNumber,
           int selectElementNumber, int searchLexemNumber)
        {
            return SelectLanguageVersionStackLexem(selectLanguage, selectVersion,
                selectStateNumber, selectElementNumber, searchLexemNumber) != null;
        }

        public bool SearchLanguageVersionSyntaxAction(string selectLanguage,
            string selectVersion, int selectStateNumber,
            int selectElementNumber, IAction searchAction)
        {
            return SelectLanguageVersionSyntaxAction(selectLanguage, selectVersion,
                selectStateNumber, selectElementNumber, searchAction) != null;
        }

        private XElement SelectLanguage(string selectLanguage)
        {
            XElement languages = dataDocument.Element("languages");
            foreach (XElement language in languages.Elements("language"))
            {
                if (language.Attribute("name").Value == selectLanguage)
                {
                    return language;
                }
            }
            return null;
        }
        
        private XElement SelectLanguageVersion(string selectLanguage, string selectVersion)
        {
            XElement language = SelectLanguage(selectLanguage);
            if (language != null)
            {
                foreach (XElement version in language.Elements("version"))
                {
                    if (version.Attribute("name").Value == selectVersion)
                    {
                        return version;
                    }
                }
            }
            return null;
        }

        private XElement SelectLanguageVersionSeparator(string selectLanguage,
            string selectVersion, Separator selectSeparator)
        {
            return SelectLanguageVersionGroupLexem(selectLanguage, selectVersion,
                "separators", "separator", selectSeparator, "With comment");
        }

        private XElement SelectLanguageVersionKeyword(string selectLanguage,
            string selectVersion, Keyword selectKeyword)
        {
            return SelectLanguageVersionGroupLexem(selectLanguage, selectVersion,
                "keywords", "keyword", selectKeyword, "With comment");
        }

        private XElement SelectLanguageVersionComment(string selectLanguage,
            string selectVersion, Comment selectComment)
        {
            return SelectLanguageVersionGroupLexem(selectLanguage, selectVersion,
                "comments", "comment", selectComment, "With comment");
        }

        private XElement SelectLanguageVersionOtherLexem(string selectLanguage,
            string selectVersion, OtherLexem selectOtherLexem)
        {
            return SelectLanguageVersionGroupLexem(selectLanguage, selectVersion,
                "otherlexems", "otherlexem", selectOtherLexem, "Without comment");
        }

        private XElement SelectLanguageIdentificator(string selectLanguage)
        {
            XElement language = SelectLanguage(selectLanguage);
            return SelectSingNode(language, "identificator");
        }

        private XElement SelectLanguageNumber(string selectLanguage)
        {
            XElement language = SelectLanguage(selectLanguage);
            return SelectSingNode(language, "number");
        }

        private XElement SelectLanguageLiteral(string selectLanguage)
        {
            XElement language = SelectLanguage(selectLanguage);
            return SelectSingNode(language, "literal");
        }

        private XElement SelectLanguageVersionSyntaxTable(string selectLanguage,
            string selectVersion)
        {
            XElement version = SelectLanguageVersion(selectLanguage, selectVersion);
            return SelectSingNode(version, "syntaxtable");
        }

        private XElement SelectLanguageVersionSyntaxState(string selectLanguage,
            string selectVersion, int selectStateNumber, string originalStateName)
        {
            XElement syntaxTable = SelectLanguageVersionSyntaxTable(selectLanguage, selectVersion);
            if (syntaxTable != null)
            {
                return SelectNodeToNumber(syntaxTable, "state", selectStateNumber, originalStateName);
            }
            return null;
        }

        private XElement SelectLanguageVersionStateElement(string selectLanguage,
            string selectVersion, int selectStateNumber, int selectElementNumber, string originalElementName)
        {
            XElement syntaxState = SelectLanguageVersionSyntaxState(selectLanguage,
                selectVersion, selectStateNumber, "original");
            if (syntaxState != null)
            {
                return SelectNodeToNumber(syntaxState, "row", selectElementNumber, originalElementName);
            }
            return null;
        }

        private XElement SelectLanguageVersionStackLexem(string selectLanguage,
            string selectVersion, int selectStateNumber, 
            int selectElementNumber, int selectLexemNumber)
        {
            XElement stateElement = SelectLanguageVersionStateElement(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, "original");
            if (stateElement != null)
            {
                XElement stack = stateElement.Element("stack");
                return SelectNodeToNumber(stack, "stacklexem", selectLexemNumber,
                    "original");
            }
            return null;
        }

        private XElement SelectLanguageVersionEnterLexem(string selectLanguage,
            string selectVersion, int selectStateNumber, int selectElementNumber)
        {
            XElement stateElement = SelectLanguageVersionStateElement(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, "original");
            return SelectSingNode(stateElement, "enterlexem");
        }

        private XElement SelectLanguageVersionSyntaxAction(string selectLanguage,
            string selectVersion, int selectStateNumber,
            int selectElementNumber, IAction selectAction)
        {
            XElement stateElement = SelectLanguageVersionStateElement(selectLanguage,
                selectVersion, selectStateNumber, selectElementNumber, "original");
            if (stateElement != null)
            {
                XElement actions = stateElement.Element("actions");
                foreach (XElement action in actions.Elements("action"))
                {
                    switch(action.Attribute("name").Value)
                    {
                        case "shift":
                            if (selectAction.Type() == ActionType.Shift)
                            {
                                return action;
                            }
                            break;
                        case "passing":
                            if (selectAction.Type() == ActionType.Passing)
                            {
                                if (selectAction.EquateTo(
                                    new PassingAction(int.Parse(action.Element("tostate").Value))))
                                {
                                    return action; 
                                }
                            }
                            break;
                        case "from":
                            if (selectAction.Type() == ActionType.From)
                            {
                                if (selectAction.EquateTo(
                                    new FromAction(int.Parse(action.Element("lexemcount").Value), 
                                        new Lexem(action.Element("tolexem").Value))))
                                {
                                    return action;
                                }
                            }
                            break;
                        case "end":
                            if (selectAction.Type() == ActionType.End)
                            {
                                return action;
                            }
                            break;
                    }
                }
            }
            return null;
        }

        private XElement SelectLanguageVersionGroupLexem(string selectLanguage,
            string selectVersion, string groupNodeName, string lexemNodeName,
            Lexem selectLexem, string selectType)
        {
            XElement version = SelectLanguageVersion(selectLanguage, selectVersion);
            if (version != null)
            {
                XElement lexems = version.Element(groupNodeName);
                foreach (XElement lexem in lexems.Elements(lexemNodeName))
                {
                    if (selectType == "Without comment")
                    {
                        if (lexem.Value == selectLexem.Item)
                        {
                            return lexem;
                        }
                    }
                    else if (selectType == "With comment")
                    {
                        if (lexem.Element("item").Value == selectLexem.Item)
                        {
                            return lexem;
                        }
                    }
                }
            }
            return null;
        }

        private XElement SelectSingNode(XElement groupNode, string singNodeName)
        {
            if (groupNode != null)
            {
                XElement singNode = groupNode.Element(singNodeName);
                return singNode;
            }
            return null;
        }
        
        private XElement SelectNodeToNumber(XElement groupNode, string nodeName,
            int selectNodeNumber, string originalNodeName)
        {
            XElement selectNode = null;
            int nodeNumber = 1;
            foreach (XElement node in groupNode.Elements(nodeName))
            {
                bool isSearch = false;
                if (originalNodeName == "copy")
                {
                    isSearch = node.Attribute("pertain").Value == "copy";
                }
                else
                {
                    isSearch = true;
                }
                if (isSearch)
                {
                    if (nodeNumber == selectNodeNumber)
                    {
                        selectNode = node;
                        break;
                    }
                    nodeNumber++;
                }
            }
            return selectNode;
        }
    }
}