namespace PolygonEditor.GlobalHelpers
{
    public static class InstructionTexts
    {
        public static readonly string[] AddCircleInstruction =
        {
            "Add Circle",
            "",
            "1. Left click to select center",
            "2. Move mouse to specify radius of circle",
            "3. Left click again to confirm radius",
            "",
            "Escape - exit",
        };

        public static readonly string[] ChangeCircleRadiusInstruction =
        {
            "Change circle radius",
            "",
            "1. Select circle by mouse left click",
            "2. Move mouse to change radius of circle",
            "3. Left click again to confirm radius",
            "",
            "Escape - exit",
        };

        public static readonly string[] AddCircleTangentConstraintInstruction =
        {
            "Make Circle tangent to polygon",
            "",
            "1. Select circle by mouse left click",
            "2. Select polygon by mouse left click",
            "",
            "Escape - exit",
            "Right mouse click - cancel selected circle",
        };

        public static readonly string[] AddConstantCenterCircleConstraintInstruction =
        {
            "Make center of circle constant",
            "",
            "1. Select circle by mouse left  click",
            "",
            "Escape - exit",
        };

        public static readonly string[] AddConstantRadiusCircleConstraintInstruction =
        {
            "Make radius of circle constant",
            "",
            "1. Select circle by mouse left click",
            "",
            "Escape - exit",
        };

        public static readonly string[] AddConstantEdgeLengthConstraintInstruction =
        {
            "Constant length of polygon edge",
            "",
            "1. Select edge",
            "2. Insert length",
            "3. Press 'OK'",
            "",
            "Escape - exit",
        };

        public static readonly string[] PerpendicularConstraintInstruction =
        {
            "Perpendicular Constraint Instruction",
            "",
            "1. Select first edge by mouse left click",
            "2. Select second edge mouse left click",
            "",
            "Right Click - cancel first selected edge",
            "Escape - exit",
        };

        public static readonly string[] SameLengthConstraintInstruction =
        {
            "Same Length Constraint Instruction",
            "",
            "1. Select first edge by mouse left click",
            "2. Select second edge mouse left click",
            "",
            "Right Click - cancel first selected  edge",
            "Escape - exit",
        };

        public static readonly string[] RemoveConstraintInstruction =
        {
            "Remove Constraint Instruction",
            "",
            "1. Right click center of constraint image to remove it",
            "",
            "Escape - exit",
        };

        public static readonly string[] MoveRasterObjectInstruction =
        {
            "Move Object Instruction",
            "",
            "1. Holding mouse left button on object move mouse to change its localization",
            "",
            "Escape - exit",
        };

        public static readonly string[] RemoveRasterObjectInstruction =
        {
            "Remove Object Instruction",
            "",
            "1. Left click object to delete it",
            "",
            "Escape - exit",
        };

        public static readonly string[] SelectionObjectInstruction =
        {
            "Remove Object Instruction",
            "",
            "1. Left click to select object",
            "",
            "Escape - exit",
        };

        public static readonly string[] AddPolygonInstruction =
        {
            "Add Polygon Instruction",
            "",
            "1. Left click to add next vertex",
            "2. Right click to submit",
            "",
            "Escape - exit",
        };

        public static readonly string[] AddVertexInstruction =
        {
            "Add Vertex Instruction",
            "",
            "1. Select polygon to add vertex",
            "2. Left Click between vertices to add vertex",
            "",
            "Right mouse click - cancel selected polygon",
            "Escape - exit",
        };
        public static readonly string[] MoveEdgeInstruction =
        {
            "Move Edge Instruction",
            "",
            "1. Select polygon to move edge",
            "2. Holding left button on edge, move mouse to change its position",
            "",
            "Right mouse click - cancel selected polygon",
            "Escape - exit",
        };
        public static readonly string[] MoveVertexInstruction =
        {
            "Move Vertex Instruction",
            "",
            "1. Select polygon to move vertex",
            "2. Holding left button on vertex, move mouse to change its position",
            "",
            "Right mouse click - cancel selected polygon",
            "Escape - exit",
        };
        public static readonly string[] RemoveVertexInstruction =
        {
            "Remove Vertex Instruction",
            "",
            "1. Select polygon to remove vertex",
            "2. Click on vertex to remove it",
            "",
            "Right mouse click - cancel selected polygon",
            "Escape - exit",
        };
    }
}