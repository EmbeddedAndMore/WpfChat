﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearningProject2.Core
{
    public static class ExpressionHelper
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        public static void SetPeopertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}
