using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        // Va a representar la condicion logica q tu quieres aplicar a una entidad
        Expression<Func<T, bool>> Criteria { get; }

        // representa las relaciones q vas a poder implentar sobre esa intedidad
        List<Expression<Func<T, object>>> Includes { get; }

        Expression<Func<T, object>> OrderBy {get;}

        Expression<Func<T, object>> OrderByDescending { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnable { get; }

    }
}
