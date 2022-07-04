using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BD_Proiect
{
    class MasterUserControlGallery
    {
        Grid masterGrid;
        Gallery.GalleryPage galleryPage;
        Gallery.ExpositionsPage expositionsPage;
        Gallery.PaintingsPage paintingsPage;
        Orders.OrderDetailsPage orderDetailsPage;
        AdminControlPage adminControlPage;

        int _galleryID = -1;
        int _expositionID = -1;
        int _userID = -1;

        public MasterUserControlGallery(Grid mainGrid)
        {
            masterGrid = mainGrid;
            newStartUp();
        }
        public void newAdminPage()
        {
            adminControlPage = new AdminControlPage();
            masterGrid.Children.Clear();
            masterGrid.Children.Add(adminControlPage);
        }
        public void newGallerySearch(int userID)
        {
            _userID = userID;
            galleryPage = new Gallery.GalleryPage();
            expositionsPage = new Gallery.ExpositionsPage();
            paintingsPage = new Gallery.PaintingsPage();
            newGallery();
        }

        private void newStartUp()
        {
            StartUpPage startUpPage = new StartUpPage();
            masterGrid.Children.Clear();
            masterGrid.Children.Add(startUpPage);
        }

        private void newOrderDetails(int operaID)
        {
            orderDetailsPage=new Orders.OrderDetailsPage(_userID,operaID);
            masterGrid.Children.Clear();
            masterGrid.Children.Add(orderDetailsPage);
            orderDetailsPage.declineOrder += newPaintings;
        }
        void newGallery()
        {
            masterGrid.Children.Clear();
            masterGrid.Children.Add(galleryPage);
            galleryPage.backToStatUp += newStartUp;
            galleryPage.getExpositions += newExpositions;
        }

        void newExpositions(int galleryID)
        {
            if (galleryID == -1)
                galleryID = _galleryID;
            else
                _galleryID = galleryID;
            expositionsPage.table(galleryID);
            masterGrid.Children.Clear();
            masterGrid.Children.Add(expositionsPage);
            expositionsPage.backToGallery += newGallery;
            expositionsPage.getPaintings += newPaintings;
        }

        void newPaintings(int expositionID)
        {
            if (expositionID == -1)
                expositionID = _expositionID;
            else
                _expositionID = expositionID;
            paintingsPage.table(expositionID);
            masterGrid.Children.Clear();
            masterGrid.Children.Add(paintingsPage);
            paintingsPage.backToExpositions += newExpositions;
            paintingsPage.newOrderPage += newOrderDetails;
            paintingsPage.backToGallery += newGallery;
        }

        public void newOrders(int userID)
        {
            Orders.OrgersPage orgersPage = new Orders.OrgersPage(userID);
            masterGrid.Children.Clear();
            masterGrid.Children.Add(orgersPage);
        }
    }
}
