using Microsoft.AspNetCore.Mvc;
using project.noname.service.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.noname.api.Controllers
{
    public class BaseController : Controller
    {
		protected new IActionResult Response(Response result = null)
		{
			if (ValidOperation(result))
			{
				if (result.Value == null)
				{
					return NoContent();
				}

				return Ok(new
				{
					success = true,
					data = result.Value
				});
			}

			return BadRequest(new
			{
				success = false,
				errors = result.ToString()
			});
		}

		private bool ValidOperation(Response response)
		{
			return !response.AnyMessage;
		}

		protected void NotificaErroModelState()
		{
			var erros = ModelState.Values.SelectMany(v => v.Errors);
			foreach (var erro in erros)
			{
				var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
			}
		}
	}
}
