using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleCrudLayerWise.Utils
{
    public static class Class1
    {
        public enum Operation
        {
            ADD_STUDENT = 1,
            DISPLAY_ALL_STUDENT,
            DISPLAY_STUDENT,
            UPDATE_STUDENT,
            ASSIGN_STUDENT_TO_CLASS,
            DELETE_STUDENT,
            ADD_CLASS,
            DISPLAY_ALL_CLASS,
            UPDATE_CLASS,
            DELETE_CLASS,
            ADD_COURSE,
            DISPLAY_ALL_COURSE,
            UPDATE_COURSE,
            ASSIGN_COURSE_TO_CLASS,
            DELETE_COURSE,
            REMOVE_STUDENT_TO_CLASS,
            REMOVE_COURSE_TO_CLASS,
            DISPLAY_ALL_STUDENT_ASSIGNIN_CLASS,
            DISPLAY_ALL_CLASS_ASSIGNIN_STUDENT,
            DISPLAY_ALL_COURSE_ASSIGNIN_CLASS,
            DISPLAY_ALL_CLASS_ASSIGNIN_COURSE,
            EXIT
        }
    }
}
