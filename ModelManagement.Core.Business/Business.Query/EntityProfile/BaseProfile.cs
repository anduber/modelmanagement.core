using AutoMapper;
using ModelManagement.Core.Business.Business.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Query.EntityProfile
{
    public abstract class BaseProfile : Profile
    {
        protected override void Configure()
        {
            CreateMappings();
        }

        protected abstract void CreateMappings();

        protected IMappingExpression<TSource, KeyDescription> MapKeyDesc<TSource>(Expression<Func<TSource, string>> keyMember, Expression<Func<TSource, string>> descriptionMember)
        {
            return CreateMap<TSource, KeyDescription>()
                .ForMember(t => t.Key, m => m.MapFrom(keyMember))
                .ForMember(t => t.Description, m => m.MapFrom(descriptionMember));
        }

        protected IMappingExpression<TSource, KeyDescriptionId> MapKeyDescId<TSource>(Expression<Func<TSource, string>> keyMember, Expression<Func<TSource, string>> descriptionMember, Expression<Func<TSource, string>> idMember)
        {
            return CreateMap<TSource, KeyDescriptionId>()
                .ForMember(t => t.Key, m => m.MapFrom(keyMember))
                .ForMember(t => t.Description, m => m.MapFrom(descriptionMember))
                .ForMember(t => t.Id, m => m.MapFrom(idMember));
        }

        protected IMappingExpression<TSource, EntityDescription> MapDesc<TSource>(Expression<Func<TSource, string>> descriptionMember)
        {
            return CreateMap<TSource, EntityDescription>()
                .ForMember(t => t.Description, m => m.MapFrom(descriptionMember));
        }
    }
}
