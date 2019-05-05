using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_EF.ViewModels
{
    public class AddOrEditViewModel : ViewModelBase


    {


        private StudentEntity _currentStudentEntity;
        public StudentEntity CurrentStudentEntity
        {
            get { return _currentStudentEntity; }
            set
            {
                if (_currentStudentEntity != value)
                {
                    _currentStudentEntity = value;
                    if (_currentStudentEntity.StudentSex == 0)
                    {
                        IsChecked = true;
                    }
                    else
                    {
                        IsChecked = false;
                    }

                    this.OnPropertyChanged(r => r.CurrentStudentEntity);
                }
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    this.OnPropertyChanged(r => r.IsChecked);
                }
            }
        }

        public StudentDal StudentDal { get; set; }

        private bool _isAdd = false;

        public bool IsAdd
        {
            get { return _isAdd; }
            set
            {
                if (_isAdd != value)
                {
                    _isAdd = value;
                    this.OnPropertyChanged(r => r.IsAdd);
                }
            }
        }
        public ICommand SaveCommand { get; set; }

        public AddOrEditViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            StudentEntity student = new StudentEntity();
            student.StudentName = CurrentStudentEntity.StudentName;
            student.StudentAge = CurrentStudentEntity.StudentAge;
            student.StudentSex = IsChecked ? 0 : 1;
            student.StudentAddress = CurrentStudentEntity.StudentAddress;
            if (IsAdd)
            {
                StudentDal.Insert(student);
            }
            else
            {
                student.StudentId = CurrentStudentEntity.StudentId;
                StudentDal.Update(student);
            }
        }
    }
}
