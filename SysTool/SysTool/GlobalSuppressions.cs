// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// scope: namespaceanddescendants
[assembly: SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:SysTool")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:SysTool")]
[assembly: SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:SysTool")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:SysTool.Models.WMI")]
[assembly: SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:SysTool")]

// scope: type
[assembly: SuppressMessage("Usage", "CA2237:Mark ISerializable types with serializable", Justification = "<Pending>", Scope = "type", Target = "~T:SysTool.Components.ComputerNode")]

// scope: member
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Program.HandleExceptions(System.Threading.Tasks.Task)")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Extensions.ObjectExtensions.PropertiesContain(System.Object,System.String,System.StringComparison)~System.Boolean")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Program.Main")]
[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Program.StartAsync~System.Threading.Tasks.Task")]
[assembly: SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>", Scope = "member", Target = "~M:SysTool.Components.Panels.ComputerPanel.InitializeAsync~System.Threading.Tasks.Task")]
