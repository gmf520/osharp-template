using System;


namespace OSharp.Template.Common.Dtos
{
    public class ModuleSetFunctionDto
    {
        public int ModuleId { get; set; }

        public Guid[] FunctionIds { get; set; }
    }
}