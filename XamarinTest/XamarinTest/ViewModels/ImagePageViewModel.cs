using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExifLib;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;
using XamarinTest.ApiModels.Models;
using XamarinTest.Models;
using XamarinTest.Services.Interfaces;
using XamarinTest.ViewModels.Base;
using XamarinTest.Views;

namespace XamarinTest.ViewModels {
    public class ImagePageViewModel : BaseViewModel {
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly IAccountService _accountService;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        public Task Initialization { get; private set; }
        private DelegateCommand GetListCommand { get; set; }
        public DelegateCommand TakePhotoCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }

        public List<ImageApiModel> Images { get; set; }

        public ImagePageViewModel(IMapper mapper, IAccountService accountService, IImageService imageService, INavigationService navigationService, IPageDialogService pageDialogService) {
            _mapper = mapper;
            _imageService = imageService;
            _accountService = accountService;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            TakePhotoCommand = new DelegateCommand(TakePhoto);
            LogoutCommand = new DelegateCommand(Logout);

            var list = Task.Run(() => ListAsync());
            var result = list.Result.ToList();
            Images = new List<ImageApiModel>(result);
        }

        public async Task<List<ImageApiModel>> ListAsync() {
            List<ImageApiModel> list = await _imageService.ListAsync();

            List<ImageModel> images = _mapper.Map<List<ImageModel>>(list);

            foreach (var image in images) {
                image.ImageSource = ImageSource.FromStream(() => new MemoryStream(image.Bytes));
            }
            return list;
        }

        private async void TakePhoto() {
            try {
                await CrossMedia.Current.Initialize();

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() {
                    PhotoSize = PhotoSize.Small, Name = DateTime.Now + "_XamarinTest.jpg", Directory = "Sample"
                });
                if (photo == null) return;
                byte[] image = File.ReadAllBytes(photo.Path);

                double[] latitude;
                double[] longitude;

                using (Stream streamPic = photo.GetStream()) {
                    var picInfo = ExifReader.ReadJpeg(streamPic);
                    latitude = picInfo.GpsLatitude;
                    longitude = picInfo.GpsLongitude;
                }

                string l1 = Helpers.ConvertationHelper.CoordinatesToString(latitude);
                string l2 = Helpers.ConvertationHelper.CoordinatesToString(longitude);

                var result = await _imageService.SaveAsync(image, l1, l2);
                if (!result.IsSuccess) {
                    await _pageDialogService.DisplayAlertAsync(result.Error, "", "OK");
                } else {
                    await _navigationService.NavigateAsync($"/{nameof(ImagePage)}");
                }

            } catch (Exception ex) {
                await _pageDialogService.DisplayAlertAsync(ex.Message, "", "OK");
            }
        }

        private async void Logout() {
            var result = await _accountService.LogoutAsync();
            if (result.IsSuccess) {
                await _navigationService.NavigateAsync($"/{nameof(LoginPage)}");
            } else {
                await _pageDialogService.DisplayAlertAsync(result.Error, "", "OK");
            }
        }
    }
}