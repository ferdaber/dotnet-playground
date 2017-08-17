using System;

namespace Playground
{
    public static class FunctionalExtensions
    {
        public static T And<T>(this T @this, Func<T, T> func) => func(@this);
        public static T Do<T>(this T @this, Action func) { func(); return @this; }
        public static T AndIf<T>(this T @this, Func<bool> predicate, Func<T, T> func) => func(@this);
        public static T DoIf<T>(this T @this, Func<bool> predicate, Action func) { func(); return @this; }
        public static T2 AndMap<T1, T2>(this T1 @this, Func<T1, T2> func) => func(@this);
        public static void AndFinally<T1>(this T1 @this, Action<T1> func) => func(@this);
        public static void DoFinally<T1>(this T1 @this, Action func) => func();
        public static Func<object, T> GetConstructor<T>() => (object param) => (T)Activator.CreateInstance(typeof(T), param);
    }
}