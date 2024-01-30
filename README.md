# MeteoriteAvoidance
<img src="https://github.com/wlgns5518/MeteoriteAvoidance/assets/128718414/faf9e2d7-cda6-41cb-b2b1-199d651fba79"> 

<img src=""> 

## 게임 소개
똥피하기 게임을 스페이스 풍으로 재해석한 게임- [운석 피하기Meteorite Avoidance]입니다!

360도 방향에서 운석들이 날아 오는 우주 환경 속, 크기와 모양이 변하는 구형 지면 위에서
다양한 효과를 가진 아이템을 주우면서 
대쉬와 점프를 통한 컨트롤로 생존하는 게임입니다.
시시각각 변하는 게임 환경 속에서 플레이어는 액션과 스릴, 도전욕구를 느낄 수 있습니다.


## 목차
 - [개요](#개요)
 - [게임 설명](#게임-설명)
 - [게임 플레이 방식](#게임-플레이-방식)
 - [역할 분담](#역할-분담)
 - [프로젝트 구현 사항 완료 여부](#프로젝트-구현사항-완료-여부)


## 개요
 - 프로젝트 이름: 운석 피하기 Meteorite Avoidance
 - 프로젝트 작업 기간: 2024.01.24 ~ 2024.01.31 
 - 개발엔진 및 언어: Unity & C#
 - 멤버: 박지훈A, 김현래, 정현우, 박재현


## 게임 설명
[시작화면 이미지] [게임화면 이미지]
자칫 지루하고 단조롭게 느껴질 수 있는 기존 똥피하기 게임의 단점에서 벗어나
우주를 배경으로 다이나믹한 액션과 짜릿함을 느낄 수 있는 플레이 경험에 중점을 두고 개발하였습니다.

-360도 어디에서든 날아오는 운석과 계속해서 바뀌는 지면!
계속해서 모양이 변하는 지구 위에서 전 방향에서 날아오는 운석을 피해 생존하세요.
변칙적으로 바뀌는 지구의 모양, 크기, 회전 속도는 플레이어에게 긴박감과 스릴을 선사합니다.

-랜덤으로 드랍되는 다양한 아이템들!
체력을 회복시켜주는 포션, 피해로부터 보호해주는 쉴드, 스태미나를 회복시켜주는 건전지, 화면의 운석을 전부 제거하는 별까지
생존에 도움을 주는 다양한 아이템들이 지면 위에 주기적으로 드랍됩니다!
아이템을 주워 생존을 용이하게 만드세요!

-지구 표면을 따라 이동하고 점프, 대쉬!
단순히 이동할 뿐만 아니라 점프를 통해 중력을 거스르고 대쉬를 통해 순간적으로 빠르게 이동하세요.
미세한 컨트롤과 판단으로 생사가 결정됩니다!


## 게임 플레이 방식
캐릭터 조작 방법
키보드 [A] [D] 또는 [←] [→]로 좌우 이동
[Space bar]로 점프, [Shift] 또는 [마우스 우클릭]으로 대쉬

아이템에 닿으면 효과를 즉시 획득합니다.
각 아이템 설명

운석에 닿으면 HP가 감소합니다.
게임 오버 시 결과창에서 최대 기록과 현재 기록이 나타나며 다시하기, 타이틀로 돌아가기, 게임 종료를 선택할 수 있습니다.


## 역할 분담
- 박지훈-씬이동 전반 및 툴팁 & UI & GUI 담당
- 정현우-플레이어&지구 오브젝트 및 그래픽 담당
- 김현래-운석 오브젝트 전반 및 이펙트 담당
- 박재현-아이템 오브젝트 전반 및 사운드 담당
- 나머지는 공동 작업


## 프로젝트 구현사항 완료 여부
-필수 구현 사항
[구현]    - 게임 화면: 게임을 플레이할 수 있는 화면을 만들어야 합니다. 화면 크기, 배경 등을 설정해야 합니다. 
[구현]    - 캐릭터: 주인공 캐릭터를 만들고, 이를 움직일 수 있도록 구현해야 합니다.
[구현]    - 똥 오브젝트: 똥 오브젝트를 생성하고, 이를 랜덤한 위치에서 아래로 떨어뜨리는 동작을 구현해야 합니다.
[구현]    - 충돌 감지: 캐릭터와 똥 오브젝트가 충돌했는지를 감지하고, 충돌 시 게임이 종료되도록 처리해야 합니다.
[구현]    - 게임 로직: 게임의 기본 로직을 구현해야 합니다. 즉, 게임 시작, 종료, 점수 등을 관리해야 합니다.

- 선택 구현 사항
[구현]    - 게임 난이도 조절: 난이도를 조절하기 위해 똥이 떨어지는 속도, 똥의 크기, 캐릭터의 이동 속도 등을 조절할 수 있습니다.
[구현]    - 배경 음악 및 효과음: 게임에 배경 음악과 효과음을 추가하여 게임의 분위기를 높일 수 있습니다.
[구현]    - 점수 시스템: 게임 플레이어의 점수를 기록하고, 최고 점수를 저장하여 랭킹 시스템을 추가할 수 있습니다.
[구현]    - 파워업 아이템: 캐릭터가 똥을 피하기 위한 파워업 아이템을 도입할 수 있습니다. 예를 들어, 보호막을 얻거나 일시적으로 똥을 없앨 수 있는 아이템을 추가할 수 있습니다.
[미구현]    - 다양한 캐릭터 선택: 여러 캐릭터 스킨을 선택할 수 있도록 하는 기능을 추가할 수 있습니다.
[구현]    - 화면 효과: 게임 중에 화면에 특수 효과를 추가하여 게임 경험을 향상시킬 수 있습니다.
[미구현]    - 다중 플레이어 모드: 다른 플레이어와 함께 플레이할 수 있는 로컬 다중 플레이어 모드를 추가할 수 있습니다.
