using Aula23.Models;
using Aula23.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula23.Controllers
{
    public class BoneController : BaseController<Bone, BoneRepository>
    {
        public BoneController() : base(new BoneRepository())
        {

        }
    }
}