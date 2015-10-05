using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.DataLayer.Repositories
{
    public class ContentRepository
    {
        private readonly BaukCMSContext _db = new BaukCMSContext();
        public Content GetContent(int contentId)
        {
            return _db.Content.AsNoTracking().FirstOrDefault(p => p.ContentId == contentId);
        }

        public List<ContentTemplate> GetContentTemplates(int siteId)
        {
            return _db.ContentTemplate.Where(p => p.SiteId == siteId).ToList();
        }

        public List<ContentItem> GetContentItems(int contentTemplateId)
        {
            return _db.ContentItem.Where(p => p.ContentTemplateId == contentTemplateId).ToList();
        }
    }
}
