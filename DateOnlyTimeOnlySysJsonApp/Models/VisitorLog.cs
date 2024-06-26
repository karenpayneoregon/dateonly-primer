﻿namespace DateOnlyTimeOnlySysJsonApp.Models;

public class VisitorLog
{
    public DateOnly VisitOn { get; set; }
    public TimeOnly EnteredTime { get; set; }
    public TimeOnly ExitedTime { get; set; }

    public override string ToString()
        => $"{VisitOn,-10}{EnteredTime,-10}{ExitedTime}";
}