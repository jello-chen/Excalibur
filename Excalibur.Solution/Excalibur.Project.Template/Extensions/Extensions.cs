using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Excalibur.Project.Template.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// 实体转为谓语表达式
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Expression<Func<TModel, bool>> ToPredicate<TModel>(this TModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            var parameter = Expression.Parameter(typeof(TModel));
            var predicateExpr = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
            var type = model.GetType();
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                var propValue = propertyInfo.GetValue(model);
                if (propValue == null) continue;
                if (propertyInfo.PropertyType == typeof(string) &&
                    string.IsNullOrEmpty(propValue.ToString())) continue;
                var defaultValue = propertyInfo.PropertyType.GetDefaultValue();
                if (!object.Equals(propValue, defaultValue))
                {
                    predicateExpr = Expression.And(predicateExpr,
                        Expression.Equal(Expression.Property(parameter, propertyInfo.Name),
                            Expression.Constant(propValue)));
                }
            }
            return Expression.Lambda<Func<TModel, bool>>(predicateExpr, parameter);
        }
        /// <summary>
        /// 获取默认值
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static object GetDefaultValue(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }


}
