using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NxtGenUG_MicroORM.Domain
{
    public partial class Genre  
    {
		  public int GenreId { get; set; }
		  public string Name { get; set; }
	}

    public partial class Invoice  
    {
		  public int InvoiceId { get; set; }
		  public int CustomerId { get; set; }
		  public DateTime InvoiceDate { get; set; }
		  public string BillingAddress { get; set; }
		  public string BillingCity { get; set; }
		  public string BillingState { get; set; }
		  public string BillingCountry { get; set; }
		  public string BillingPostalCode { get; set; }
		  public decimal Total { get; set; }
	}

    public partial class InvoiceLine  
    {
		  public int InvoiceLineId { get; set; }
		  public int InvoiceId { get; set; }
		  public int TrackId { get; set; }
		  public decimal UnitPrice { get; set; }
		  public int Quantity { get; set; }
	}

    public partial class MediaType  
    {
		  public int MediaTypeId { get; set; }
		  public string Name { get; set; }
	}
	 
    public partial class Playlist  
    {
		  public int PlaylistId { get; set; }
		  public string Name { get; set; }
	}

    public partial class PlaylistTrack  
    {
		  public int PlaylistId { get; set; }
		  public int TrackId { get; set; }
	}

    public partial class Track  
    {
		  public int TrackId { get; set; }
		  public string Name { get; set; }
		  public int? AlbumId { get; set; }
		  public int MediaTypeId { get; set; }
		  public int? GenreId { get; set; }
		  public string Composer { get; set; }
		  public int Milliseconds { get; set; }
		  public int? Bytes { get; set; }
		  public decimal UnitPrice { get; set; }
	}

    public partial class Album  
    {
		  public int AlbumId { get; set; }
		  public string Title { get; set; }
		  public int ArtistId { get; set; }
	}

    public partial class Artist  
    {
		  public int ArtistId { get; set; }
		  public string Name { get; set; }
	}
}
