# Punkland UI Builder

기존 레이아웃 매니저의 단점, UI 스크립트의 단점을 개선하여 펑크랜드 UI 스크립트 개발을 더욱 편리하게 도와주는 Unity 프로젝트 입니다.

기존에는 각 UI 컨트롤을 아래와 같이 일일이 코드로 작성해야 했고, 변경 사항을 확인하려면 매번 프로그램을 재실행해야 했기 때문에 개발 효율이 떨어지고 실시간 작업이 어려웠습니다.
``` lua
local btn = Button(Rect(0, 0, 123, 23))  
btn.opacity = 155
```

또한 레이아웃 매니저를 사용하더라도 지원되지 않는 일부 컨트롤과 프로퍼티가 있었으며, 프로그램 조작 중 오류가 자주 발생하는 등의 안정성 문제도 있었습니다.
위 두개의 단점을 모두 해결하기 위해 제작하게 되었습니다.

사용 방법은 [여기](https://cafe.naver.com/nekolandgames/28394)를 눌러 확인해주세요.

펑크랜드에서 Export된 데이터를 빌드하려면 [LPage.lua](https://github.com/ljs0218/LPage.lua) 라이브러리가 필요합니다.

2025-04-18
- ViewPort 컨트롤 Hierachy 표기 안 됨 수정
- BaseControl 클래스 scaleX, scaleY 프로퍼티 추가
- Control 클래스 border 관련 프로퍼티 추가
- BaseControl 클래스 maksed 추가
