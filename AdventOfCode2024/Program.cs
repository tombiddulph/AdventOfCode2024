
using System.Reflection;

Assembly.GetExecutingAssembly().GetTypes().Where(type => type.Name.StartsWith("Day"))
    .Select(type => type.GetMethods(BindingFlags.Public | BindingFlags.Static)).SelectMany(method => method)
    .OrderByDescending(method => int.Parse(method.DeclaringType!.Name.Replace("Day", string.Empty))).ToList().ForEach(
        method => Console.WriteLine(
            $"{method.DeclaringType!.Name} {method.Name} result: {method.Invoke(null, null)}"));
            