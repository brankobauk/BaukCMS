using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.BusinessLogic.Contents
{
    public class ContentManager
    {
        private readonly ContentRepository _contentRepository = new ContentRepository();
        public Content GetContent(int contentId)
        {
            return _contentRepository.GetContent(contentId);
        }

        public List<ContentTemplate> GetContentTemplates(int siteId)
        {
            return _contentRepository.GetContentTemplates(siteId);
        }

        public List<ContentItem> GetContentItems(int contentTemplateId)
        {
            return _contentRepository.GetContentItems(contentTemplateId);
        }

        internal object GetContentItemValues(int contentTemplateId)
        {
            throw new NotImplementedException();
        }
    }
}
