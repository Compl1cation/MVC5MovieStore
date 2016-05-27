using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5MovieStore.ViewModels
{
    public class AssignGenreData
    {
	public int GenreId {get; set;}
	public string Name {get; set;}
	public bool Assigned {get; set;}
    }
}