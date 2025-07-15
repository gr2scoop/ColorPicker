# ColorPicker 🎨

ColorPicker는 Windows Forms 기반의 간단한 색상 추출 도구입니다.  
화면의 특정 지점을 클릭하면 해당 위치의 색상을 추출하고, RGB 및 HEX 값을 확인할 수 있습니다.

## ✨ 기능 소개

- 화면에서 마우스 클릭으로 색상 추출
- 추출된 색상의 RGB 및 HEX 코드 확인
- 복사 기능 지원 (예: 클립보드로 HEX 복사)
- 심플하고 직관적인 UI

## 🛠️ 기술 스택

- C# (.NET Framework 4.8)
- Windows Forms (WinForms)
- Visual Studio 2022 이상 권장

## 📸 스크린샷

> (여기에 앱 실행 화면을 캡처해서 첨부하면 좋습니다)

## 🚀 실행 방법

1. Visual Studio로 `ColorPicker.sln` 열기
2. `F5` 또는 `Ctrl + F5`로 실행

## 📂 프로젝트 구조

```
ColorPicker/
├── Form1.cs                # 메인 폼 로직
├── Program.cs              # 앱 진입점
├── Properties/             # 리소스 및 설정 파일
├── bin/, obj/              # 빌드 산출물 (Git에서 제외됨)
└── ColorPicker.sln         # 솔루션 파일
```

## 📄 라이선스

이 프로젝트는 [MIT License](LICENSE)를 따릅니다.
