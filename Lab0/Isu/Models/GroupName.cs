namespace Isu.Models;

public class GroupName
{
    public GroupName(string groupName)
    {
        Value = groupName;
    }

    public string Value { get; }
    public static bool TryParse(string groupName, out GroupName? group)
    {
        group = null;

        if (groupName.Length > 6)
        {
            return false;
        }

        int startIndexFaculty = 0;
        int lengthNumberFaculty = 1;
        string substringFaculty = groupName.Substring(startIndexFaculty, lengthNumberFaculty);

        int startIndexFacultyEducation = 1;
        int lengthNumberFacultyEducation = 1;
        string substringFacultyEducation = groupName.Substring(startIndexFacultyEducation, lengthNumberFacultyEducation);

        int startIndexNumberCourse = 2;
        int lengthNumberCourse = 1;
        string substringCourse = groupName.Substring(startIndexNumberCourse, lengthNumberCourse);
        int parsingCourse;

        int startIndexNumberGroup = 3;
        int lengthNumberGroup = 2;
        string substringGroupName = groupName.Substring(startIndexNumberGroup, lengthNumberGroup);
        int parsingGroupName;

        int startIndexDirection = 5;
        int lengthNumberDirection = 1;
        string substringDirection = groupName.Substring(startIndexDirection, lengthNumberDirection);
        int parsingDirection;

        if (int.TryParse(substringFaculty, out _))
        {
            return false;
        }

        if (!int.TryParse(substringFacultyEducation, out _))
        {
            return false;
        }

        if (!int.TryParse(substringCourse, out parsingCourse))
        {
            return false;
        }

        if ((parsingCourse < 0) || (parsingCourse >= 5))
        {
            return false;
        }

        if (!int.TryParse(substringGroupName, out parsingGroupName))
        {
            return false;
        }

        if (parsingGroupName < 0 || parsingGroupName > 15)
        {
            return false;
        }

        if (!int.TryParse(substringDirection, out parsingDirection))
        {
            return false;
        }

        if (parsingDirection < 0 || parsingDirection >= 7)
        {
            return false;
        }

        if (string.IsNullOrEmpty(substringFaculty))
        {
            return false;
        }

        if (string.IsNullOrEmpty(substringFacultyEducation))
        {
            return false;
        }

        if (string.IsNullOrEmpty(substringCourse))
        {
            return false;
        }

        if (string.IsNullOrEmpty(substringGroupName))
        {
            return false;
        }

        if (string.IsNullOrEmpty(substringDirection))
        {
            return false;
        }

        group = new GroupName(groupName);
        return true;
    }
}