# 🎥 Video to GIF Converter
A simple WPF application that converts MP4 videos to GIF format. Built with the MVVM pattern, leveraging the **Microsoft Community Toolkit** for clean and maintainable code. Designed for reusability with modular components, custom styles, Linq, dynamic UI interactions,and robust testing using Test-Driven Development (TDD) using NUnit.

## 🚀 Features
- ✅ **MP4 to GIF Conversion**  
- 📂 **Folder Selection (Input & Output)**  
- 📋 **Dynamic Video List**  
- ⚡ **Progress Bar for Conversion Status**  
- 🎨 **Custom Styles & Triggers**  
- 🔄 **MVVM Architecture with ViewModels & Data Binding**  
- 📊 **LINQ for Efficient Data Querying & Filtering**  
- 🏗️ **MVVM with and without Attributes for Flexibility**  
- 🔗 **RelayCommand & Value Converters for Robust Interaction**
- 🧪 **Test-Driven Development (TDD) with NUnit for Reliable Code**
 

## 🗂️ Project Structure  
```
VideoToGifConverter/
├── Converter/
│   └── BoolToVisibilityConverter.cs
├── Helper/
│   └── Mp4ToGifHelper.cs
├── Model/
│   └── Mp4Object.cs
├── ViewModel/
│   ├── FolderComponentVM.cs
│   ├── MainWindowVM.cs
│   ├── ProgressBarComponentVM.cs
│   └── VideoListVM.cs
├── Views/
│   ├── FileLocationUCView.xaml
│   ├── FileLocationUCView.xaml.cs
│   ├── ProgressBarUCView.xaml
│   ├── ProgressBarUCView.xaml.cs
│   ├── VideoListUCView.xaml
│   └── VideoListUCView.xaml.cs
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
└── MainWindow.xaml.cs
VideoToGifConverter.UnitTests/
├── ConverterTests/
│   └── BoolToVisibilityConverterTests.cs
├── HelperTests/
│   └── Mp4ToGifHelperTests.cs
```


## ⚡ Technologies Used
- **WPF** (Windows Presentation Foundation)  
- **MVVM Pattern** (Model-View-ViewModel)  
- **Microsoft Community Toolkit** (MVVM Helpers)  
- **MediaToolkit** (Video Processing)  
- **C# (.NET 8)**
- **Nunit** (Unit Test Framework)

## 🏗️ Getting Started

### 🔧 Prerequisites
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later  
- .NET 8.0 SDK or higher

### 🚀 Run Locally
1. Clone the repository:  
   ```bash
   git clone https://github.com/souravkh/VideoToGifConverter.git
   cd VideoToGifConverter
