using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace NStruct.Validation
{
    /// <summary>
    /// The nstruct validator.
    /// </summary>
    public static class Validator
    {
        internal static List<Type> TransparentProviders = new List<Type>();

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="obj">The object.</param>
        public static void Validate<TValue>(TValue obj)
            where TValue : class
        {
            AgainstNullArgument("obj", obj);

            var result = TryValidate(obj);
            if (!result.Success)
            {
                throw new ValidationException(result.ValidationResults);
            }
        }

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ValidationException"></exception>
        public static void Validate<TValue>(TValue obj, string message)
            where TValue : class
        {
            AgainstNullArgument("obj", obj);

            var result = TryValidate(obj);
            if (!result.Success)
            {
                throw new ValidationException(message);
            }
        }

        /// <summary>
        /// Tries the validate.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static IValidationResultContext TryValidate<TValue>(TValue obj)
            where TValue : class
        {
            if (TransparentProviders.All(o => o != typeof(TValue)))
            {
                TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(TValue), typeof(TValue)), typeof(TValue));
            }

            var context = new ValidationContext(obj, null, null);
            var results = new List<ValidationResult>();

            var valid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, context, results, true);
            if (valid)
            {
                return new ValidationResultContext();
            }
            else
            {
                var resultSet = results.Select(o => new DefaultValidationResult(o.ErrorMessage, o.MemberNames));

                return new ValidationResultContext(resultSet);
            }
        }

        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks><typeparamref name="TArgument"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        public static void AgainstNullArgument<TArgument>(string parameterName, [ValidatedNotNull]TArgument argument) where TArgument : class
        {
            AgainstNullArgument(parameterName, argument == null);
        }

        /// <summary>
        /// Guards against a null argument.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argumentNullCheckFunc">The argument null check function.</param>
        public static void AgainstNullArgument(string parameterName, [ValidatedNotNull]Func<bool> argumentNullCheckFunc)
        {
            if (argumentNullCheckFunc == null)
            {
                throw new ArgumentNullException("argumentNullCheckFunc");
            }

            if (parameterName == null)
            {
                throw new ArgumentNullException("parameterName");
            }

            bool isNull = argumentNullCheckFunc();

            AgainstNullArgument(parameterName, isNull);
        }

        /// <summary>
        /// Guards against a null argument if <typeparamref name="TArgument" /> can be <c>null</c>.
        /// </summary>
        /// <typeparam name="TArgument">The type of the argument.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="argument">The argument.</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="argument" /> is <c>null</c>.</exception>
        /// <remarks>
        /// Performs a type check to avoid boxing of value type objects.
        /// </remarks>
        public static void AgainstNullArgumentIfNullable<TArgument>(string parameterName, [ValidatedNotNull]TArgument argument)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (typeof(TArgument).IsNullableType() && argument == null)
            {
                throw new ArgumentNullException(parameterName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", parameterName));
            }
        }

        /// <summary>
        /// Guards against a null argument property value.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="argumentProperty">The argument property.</param>
        /// <exception cref="System.ArgumentException"><paramref name="argumentProperty" /> is <c>null</c>.</exception>
        /// <remarks><typeparamref name="TProperty"/> is restricted to reference types to avoid boxing of value type objects.</remarks>
        public static void AgainstNullArgumentProperty<TProperty>(string parameterName, string propertyName, [ValidatedNotNull]TProperty argumentProperty)
            where TProperty : class
        {
            if (argumentProperty == null)
            {
                string combinedParameterName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", parameterName, propertyName);
                throw new ArgumentNullException(string.Format(CultureInfo.InvariantCulture, "{0} is null.", combinedParameterName), combinedParameterName);
            }
        }

        /// <summary>
        /// Guards against a null argument property value if <typeparamref name="TProperty"/> can be <c>null</c>.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="argumentProperty">The argument property.</param>
        /// <exception cref="System.ArgumentException"><paramref name="argumentProperty" /> is <c>null</c>.</exception>
        /// <remarks>
        /// Performs a type check to avoid boxing of value type objects.
        /// </remarks>
        public static void AgainstNullArgumentPropertyIfNullable<TProperty>(
            string parameterName, string propertyName, [ValidatedNotNull]TProperty argumentProperty)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (typeof(TProperty).IsNullableType() && argumentProperty == null)
            {
                string combinedParameterName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", parameterName, propertyName);
                throw new ArgumentNullException(string.Format(CultureInfo.InvariantCulture, "{0} is null.", combinedParameterName), combinedParameterName);
            }
        }



        /// <summary>
        /// Guards against value null post condition errors.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="exceptionCreator">The exception creator.</param>
        public static void AgainstNull<TValue, TException>([ValidatedNotNull]TValue value, Func<TException> exceptionCreator)
            where TException : Exception
        {
            AgainstNullArgument("exceptionCreator", exceptionCreator);

            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (value == null)
            {
                Exception exception = exceptionCreator();

                AgainstNull(exception, "Post condition exception cretor cannot return null exception.");

                throw exception;
            }
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="NStruct.CoreException"></exception>
        public static void AgainstNull<TValue>([ValidatedNotNull]TValue value, string exceptionMessage)
        {
            if (value == null)
            {
                throw new CoreException(exceptionMessage);
            }
        }

        /// <summary>
        /// Guards against post condition errors.
        /// </summary>
        /// <param name="postCondition">if set to <c>true</c> [post condition].</param>
        /// <param name="exceptionMessage">The exception message.</param>
        /// <exception cref="ValidationException">Thrown when the post condition is not satisfied.</exception>
        public static void Against(bool postCondition, string exceptionMessage)
        {
            if (postCondition)
            {
                throw new CoreException(exceptionMessage);
            }
        }

        /// <summary>
        /// Guards against post condition errors.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="postCondition">if set to <c>true</c> [post condition].</param>
        /// <param name="exceptionCreator">The exception creator.</param>
        public static void Against<TException>(bool postCondition, Func<TException> exceptionCreator)
            where TException : Exception
        {
            AgainstNullArgument("exceptionCreator", exceptionCreator);

            if (postCondition)
            {
                Exception exception = exceptionCreator();

                AgainstNull(exception, "Post condition exception cretor cannot return null exception.");

                throw exception;
            }
        }

        /// <summary>
        /// Throws <exception cref="ArgumentNullException">exception</exception> for the specified parameter name if isNull is true
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="isNull">The variable that indicates if the parameter is null.</param>
        // ReSharper disable once UnusedParameter.Local
        private static void AgainstNullArgument(string parameterName, bool isNull)
        {
            if (parameterName == null)
            {
                throw new ArgumentNullException("parameterName");
            }

            if (isNull)
            {
                throw new ArgumentNullException(parameterName, string.Format(CultureInfo.InvariantCulture, "{0} is null.", parameterName));
            }
        }

        /// <summary>
        /// Determines whether the specified type is a nullable type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type is a nullable type; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsNullableType(this Type type)
        {
            return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// When applied to a parameter, this attribute provides an indication to code analysis that the argument has been null checked.
        /// </summary>
        private sealed class ValidatedNotNullAttribute : Attribute
        {
        }
    }
}
