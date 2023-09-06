using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileApplication.Model.Tools
{
    public class ViewerList<TypeElement>
    {
        private List<TypeElement> _elements;

        private bool _isNotEmptyList;

        public int CurrentIndex { get; private set; }

        public int Count
        {
            get { return _elements.Count; }
        }

        public ViewerList()
        {
            _elements = new List<TypeElement>();
            StartCurrentElementPosition();
        }

        public ViewerList(List<TypeElement> elements)
        {
            _elements = elements;
            StartCurrentElementPosition();
        }

        public List<TypeElement> ToList()
        {
            return _elements;
        }

        private void StartCurrentElementPosition()
        {
            _isNotEmptyList = Count > 0;
            CurrentIndex = Convert.ToInt32(_isNotEmptyList) - 1;
        }

        public void AddNewElement(TypeElement element)
        {
            _elements.Add(element);
            if(_isNotEmptyList)
            {
                IsLastElement();
            }
            else
            {
                StartCurrentElementPosition();
            }
        }

        public TypeElement GetCurrentElement()
        {
            if (_isNotEmptyList)
            {
                return _elements[CurrentIndex];
            }
            else
            {
                return default(TypeElement);
            }
        }

        public bool SetCurrentElement(TypeElement element)
        {
            if (_isNotEmptyList)
            {
                _elements[CurrentIndex] = element;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCurrentElement()
        {
            if(_isNotEmptyList)
            {
                if(CurrentIndex == 0)
                {
                    _elements.RemoveAt(CurrentIndex);
                    StartCurrentElementPosition();
                }
                else if(CurrentIndex == Count - 1)
                {
                    _elements.RemoveAt(CurrentIndex);
                    IsPreviousElement();
                }
                else
                {
                    _elements.RemoveAt(CurrentIndex);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditCurrentElementPosition(int changePosition)
        {
            if(_isNotEmptyList)
            {
                if(changePosition < Count)
                {
                    TypeElement changeElement = GetCurrentElement();
                    DeleteCurrentElement();
                    if(changePosition == Count)
                    {
                        _elements.Add(changeElement);
                    }
                    else
                    {
                        _elements.Insert(changePosition, changeElement);
                    }
                    CurrentIndex = changePosition;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsFirstElement()
        {
            return MovingIndexTermValidate(
                _isNotEmptyList, 
                0);
        }

        public bool IsPreviousElement()
        {
            return MovingIndexTermValidate(
                _isNotEmptyList & CurrentIndex > 0, 
                CurrentIndex - 1);
        }

        public bool IsNextElement()
        {
            return MovingIndexTermValidate(
                _isNotEmptyList & CurrentIndex < Count - 1, 
                CurrentIndex + 1);
        }

        public bool IsLastElement()
        {
            return MovingIndexTermValidate(
                _isNotEmptyList,
                Count - 1);
        }

        private bool MovingIndexTermValidate(bool term, int newCurrentIndex)
        {
            if (term)
            {
                CurrentIndex = newCurrentIndex;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}