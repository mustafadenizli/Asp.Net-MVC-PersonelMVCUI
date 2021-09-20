$(function(){
 $("#tblAdresler").DataTable({
        "language": {
           "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });

 $("#tblAdresler").on("click",".btnAdresSil", function(){
           var btn = $(this); 
           bootbox.confirm("Adresi silmek istediğinizden emin misiniz?", function(result){
            if(result){
            var id = btn.data("id");
           
            //alert(id);
            //ajax çağrısı yapma
            $.ajax({
            type:"Get",
            url:"/Address/Sil/" + id,
            success: function(){
             //console.log("silme işlemi başarılı");
            //parent kullanılarak butonun bulunduğu bir üste çıkıldı yani td ye sonra tekrar parent diyerek tr'ye çıktık
            //tr ise siinmek istenen satır olduğu için remove ettik. 
             btn.parent().parent().remove();
            }
           });
          }
         });
        
           
          
       
       
    });


});
