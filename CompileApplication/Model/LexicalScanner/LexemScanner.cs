using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CompileApplication.Model.LanguageStruct;
using CompileApplication.Model.LexemTypes;
using CompileApplication.Model.Tools;

namespace CompileApplication.Model.LexicalScanner
{
    public class LexemScanner
    {
        private readonly string[] CodeText;

        private readonly LanguageStruct.Version CurrentVersion;

        public LexemScanner(string[] code, string language, string version)
        {
            CodeText = code;
            LanguageData data = new LanguageData();
            CurrentVersion = 
                data.LanguageVersion(language, version);
        }

        public List<CodeLexem> CodeLexemScanner(out int errorsCount)
        {
            List<CodeLexem> findLexems = new List<CodeLexem>();
            string NumIdentPattern = @"[0-9]|[A-Za-z]|[А-Яа-я]|[_]";
            string findWord = "";
            TextCharPosition startWordPosition;
            for (int rowIndex = 0; rowIndex < CodeText.Length; rowIndex++)
            {
                startWordPosition = new TextCharPosition(rowIndex, 0);
                for (int charIndex = 0; charIndex < CodeText[rowIndex].Length; charIndex++)
                {
                    TextCharPosition startIndexs = 
                        new TextCharPosition(rowIndex, charIndex);
                    if (IsCommentLexem(ref rowIndex, ref charIndex, 
                        out Lexem findComment))
                    {
                        findLexems.Add(new CodeLexem(startIndexs, 
                            findComment));
                    }
                    else if (IsLiteralLexem(rowIndex, ref charIndex, 
                        out Lexem nowSeparatorLexem,  out Lexem findLiteral))
                    {
                        findLexems.Add(new CodeLexem(startIndexs,
                            nowSeparatorLexem));
                        startIndexs.CharNumber += 1;
                        findLexems.Add(new CodeLexem(startIndexs, 
                            findLiteral));
                        if (findLiteral is Literal)
                        {
                            startIndexs.CharNumber += charIndex;
                            findLexems.Add(new CodeLexem(startIndexs,
                                nowSeparatorLexem));
                        }
                    }
                    else if (CodeText[rowIndex][charIndex] == ' ')
                    {
                        if (findWord.Length > 0)
                        {
                            findLexems.Add(new CodeLexem(startWordPosition,
                                DefineSearchLexem(findWord)));
                            findWord = "";
                        }
                        startWordPosition =
                            new TextCharPosition(rowIndex, charIndex + 1);
                    }
                    else if (Regex.Match(CodeText[rowIndex][charIndex].ToString(),
                        NumIdentPattern).Success)
                    {
                        findWord += CodeText[rowIndex][charIndex].ToString();
                    }
                    else
                    {
                        if (findWord.Length > 0)
                        {
                            findLexems.Add(new CodeLexem(startWordPosition,
                                DefineSearchLexem(findWord)));
                            findWord = "";
                        }
                        findLexems.Add(new CodeLexem(startIndexs,
                            FindSeparator(rowIndex, ref charIndex)));
                        startWordPosition =
                            new TextCharPosition(rowIndex, charIndex + 1);
                    }
                }
                if (findWord.Length > 0)
                {
                    findLexems.Add(new CodeLexem(startWordPosition,
                        DefineSearchLexem(findWord)));
                    findWord = "";
                }
            }
            errorsCount = ErrorsCount(findLexems);
            return findLexems;
        }

        private bool IsCommentLexem(ref int lineIndex, ref int charIndex,
            out Lexem findComment)
        {
            foreach (Comment comment in CurrentVersion.Comments.ToList())
            {
                if (comment.Item.Contains("..."))
                {
                    Tuple<string, string> multiComment = MultilineCommentLexems(comment);
                    if (CodeText[lineIndex].IndexOf(multiComment.Item1) == charIndex)
                    {
                        for (int commentIndex = lineIndex; 
                            commentIndex < CodeText.Length; commentIndex++)
                        {
                            if (CodeText[commentIndex].Contains(multiComment.Item2))
                            {
                                lineIndex = commentIndex;
                                charIndex = 
                                    CodeText[commentIndex].IndexOf(multiComment.Item2) +
                                    multiComment.Item2.Length - 1;
                                findComment = comment;
                                return true;
                            }
                        }
                        lineIndex = CodeText.Length - 1;
                        charIndex = CodeText[lineIndex].Length - 1;
                        findComment = new NonLexem(multiComment.Item1);
                        return true;
                    }
                }
                else
                {
                    if (CodeText[lineIndex].IndexOf(comment.Item) == charIndex)
                    {
                        charIndex = CodeText[lineIndex].Length - 1;
                        findComment = comment;
                        return true;
                    }
                }
            }
            findComment = null;
            return false;
        }

        private bool IsLiteralLexem(int lineIndex, ref int startCharIndex, 
            out Lexem findSeparatorLiteral, out Lexem findLiteral)
        {
            char nowChar = CodeText[lineIndex][startCharIndex];
            if (nowChar == '\'' || nowChar == '"')
            {
                findSeparatorLiteral = FindSeparator(lineIndex, ref startCharIndex);
                startCharIndex += 1;
                int lastLiteralCharIndex =
                    CodeText[lineIndex].IndexOf(nowChar, startCharIndex);
                if (lastLiteralCharIndex > startCharIndex)
                {
                    findLiteral = new Literal(
                        CodeText[lineIndex].Substring(startCharIndex,
                        lastLiteralCharIndex - startCharIndex));
                    startCharIndex = lastLiteralCharIndex;
                    return true;
                }
                if (lastLiteralCharIndex == startCharIndex)
                {
                    findLiteral = new Literal("");
                    return true;
                }
                else
                {
                    lastLiteralCharIndex = CodeText[lineIndex].Length - 1;
                    findLiteral = new NonLexem(
                        CodeText[lineIndex].Substring(startCharIndex,
                        lastLiteralCharIndex - startCharIndex + 1));
                    startCharIndex = lastLiteralCharIndex;
                    return true;
                }
            }
            findSeparatorLiteral = null;
            findLiteral = null;
            return false;
        }

        private bool IsKeywordLexem(string searchWord, out Keyword findKeyword)
        {
            foreach (Keyword keyword in CurrentVersion.Keywords.ToList())
            {
                if (searchWord == keyword.Item)
                {
                    findKeyword = keyword;
                    return true;
                }
            }
            findKeyword = null;
            return false;
        }
        
        private bool IsIdentificator(string searchWord, out Identificator findIdentificator)
        {
            string NumIdentPattern = @"[A-Za-z]|[А-Яа-я]|[_]";
            if (Regex.Match(searchWord[0].ToString(), NumIdentPattern).Success)
            {
                findIdentificator = new Identificator(searchWord);
                return true;
            }
            findIdentificator = null;
            return false;
        }

        private Lexem FindSeparator(int lineIndex, ref int charIndex)
        {
            foreach (Separator separator in CurrentVersion.Separators.ToList())
            {
                int findSeparatorIndex = 
                    CodeText[lineIndex].IndexOf(separator.Item, charIndex);
                if (findSeparatorIndex == charIndex)
                {
                    charIndex += separator.Item.Length - 1;
                    return separator;
                }
            }
            return new NonLexem(
                CodeText[lineIndex][charIndex].ToString());
        }

        private Lexem DefineSearchLexem(string searchWord)
        {
            if (IsKeywordLexem(searchWord, out Keyword findKeyword))
            {
                return findKeyword;
            }
            else if (Double.TryParse(searchWord, out double result))
            {
                return new Number(searchWord);
            }
            else if (IsIdentificator(searchWord, out Identificator findIdentificator))
            {
                return findIdentificator;
            }
            else
            {
                return new NonLexem(searchWord);
            }
        }

        private Tuple<string, string> MultilineCommentLexems(Comment comment)
        {
            int dotIndex = comment.Item.IndexOf("...");
            return Tuple.Create(comment.Item.Remove(dotIndex),
                comment.Item.Remove(0, dotIndex + 3));
        }

        private int ErrorsCount(List<CodeLexem> lexems)
        {
            int errors = 0;
            foreach(CodeLexem lexem in lexems)
            {
                if (lexem.Lexem is NonLexem)
                {
                    errors++;
                }
            }
            return errors;
        }
    }
}