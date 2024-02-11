using System;
using System.Text;

namespace DtoMapperPlugin
{
    class ScopeTracker : IDisposable
    {
        public ScopeTracker(CodeWriter parent)
        {
            Parent = parent;
        }
        public CodeWriter Parent { get; }

        public void Dispose()
        {
            Parent.EndScope();
        }
    }
    public class CodeWriter
    {
        private readonly ScopeTracker scopeTracker;
        private readonly StringBuilder content;
        private int indentLevel;
        public CodeWriter()
        {
            content = new StringBuilder();
            scopeTracker = new ScopeTracker(this);
        }
        public void AddUsing(string @using) => content.Append("using ").Append(@using).AppendLine(";");
        public void AppendLine(string line) => content.Append(new string('\t', indentLevel)).AppendLine(line);
        public void AppendLine() => content.AppendLine();
        public void Append(string line) => content.Append(line);
        public IDisposable BeginScope(string line)
        {
            AppendLine(line);
            return BeginScope();
        }
        public IDisposable BeginScope()
        {
            content.Append(new string('\t', indentLevel)).AppendLine("{");
            indentLevel++;
            return scopeTracker;
        }
        public void EndLine() => content.AppendLine();

        public void EndScope()
        {
            indentLevel--;
            content.Append(new string('\t', indentLevel)).AppendLine("}");
        }

        public void StartLine() => content.Append(new string('\t', indentLevel));
        public override string ToString() => content.ToString();
    }
}
