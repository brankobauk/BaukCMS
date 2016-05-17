using BaukCMS.Helpers.DropDownHelpers;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaukCMS.BusinessLogic.Contents
{
     public class ContentHandler
     {
         private readonly ContentManager _contentManager = new ContentManager();
         private readonly DropDownHelper _dropdownHelper = new DropDownHelper();
         public ContentTemplateViewModel GetContentTemplatesViewModel(int siteId)
         {
             var contentTemplateViewModel = new ContentTemplateViewModel()
                 {
                     ContentTemplates = _dropdownHelper.GetContentTemplateListForDropDown(_contentManager.GetContentTemplates(siteId))
                 };
             return contentTemplateViewModel;
         }

         public ContentItemValueViewModel GetContentViewModel(int contentTemplateId)
         {
             var contenItems = _contentManager.GetContentItems(contentTemplateId);
             var contentItemValues = new List<ContentItemValue>();
             foreach(var contentItem in contenItems)
             {
                 var contentItemValue = new ContentItemValue()
                 {
                    ContentItemId = contentItem.ContentItemId,
                    SiteId = contentItem.SiteId
                 };
                 contentItemValues.Add(contentItemValue);
             }
             var contentItemValueViewModel = new ContentItemValueViewModel()
             {
                 ContentItemValues = contentItemValues,
                 Content = new Content() { 
                    ContentName = ""
                 }
             };
             return contentItemValueViewModel;
         }
     }
}
