$(document).ready(function () {
    
    $(".loadRelated").click(function () {
		getrelated(articleID);
        $(".related-column").animate({ "opacity": "0" });
      
        var clicked = $(this).find("span").prop('id');
        if (!$(this).hasClass("tab-current") && !$(this).hasClass("disabled")) {
            $(".tab-current").removeClass("tab-current");
            $(this).addClass("tab-current");
            getrelated(clicked, 1);
        }
    });   

    var loaded = false;
    function getrelated(articleID) 
	{        
        $.ajax({
            type: "GET",
            url: "/api/articles/" + ID + "/related",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (articles) 
			{
				var $this = $(this);
				var htmlRelated = "";
				
				articles.each(function(){
					htmlRelated += "<div class='relatedItem'><a href='/articles/" + $this.slug "'>";
					htmlRelated += $this.title;
					htmlRelated += "<img src='" + $this.imageUrl + "' alt='" + $this.imageAltText + "'/></a>";
				);
					
				$(".related_content").html(htmlRelated); 
				
				(".relatedItem").css("opacity","0").each(function (i) {
                   $(this).delay(i*50).animate({ "opacity": "1" });
                });	
            },
            error: function () { 
				console.log("There was an error retrieving related information.");			
            }
        });
    }
});