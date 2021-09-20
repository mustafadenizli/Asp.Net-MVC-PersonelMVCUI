  $(function(){
     //dataplugin'i Departmanlarda uygulamış olduk.
      $("#tblDepartmanlar").DataTable( {
        "language": {
           "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    });
      $("#tblDepartmanlar").on("click", ".BtnDepartmanSil",function(){
         var btn= $(this);
         //alert(id);
//Silme işlemini ajax ile yapma
       bootbox.confirm("Departmanı silmek istediğinize emin misiniz?", function(result){
       if(result){
        var id = btn.data("id");
         
        $.ajax({
          type: "GET",
          url:"/Departman/Sil/"+id,
          success:function(){
       //sil butonuna basıldıktan sonra satırın silinmesi işlemi
         btn.parent().parent().remove();
        //console.log("SİLME İŞLEMİ BAŞARILI...");

          }
       });
     }
       
  })
    
    });
  


   
});




