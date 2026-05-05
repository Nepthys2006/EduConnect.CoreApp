using System;
using System.Collections.Generic;
using System.Text;

namespace EduConnect.SharedUI.Models
{
    internal class Assignments
    {
        public string AssignmentId { get; set; }
        public string AssignmentTitle { get; set; }
        public string AssignmentDescription { get; set; }
        public string AssignmentDueDate { get; set; }
        public double TotalPoints { get; set; }
        public string AssignmentType { get; set; }
        public string AssignmentStatus { get; set; } 
        public string AssignmentAttachements { get; set; }


    }
}
