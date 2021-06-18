# URP_StylizedLitShader
URP Stylized Lit Shader Repository

이 저장소는 2020.3.7f1으로 작업되었습니다. 

URP 패키지는 10.4 버전 이상을 사용해 주세요 

안녕하세요 프리랜서 테크니컬 아티스트 마둠파입니다. 

![image](https://user-images.githubusercontent.com/35050187/100261095-9adcfc00-2f8d-11eb-8d21-866438c88b71.png)

Stylied Lit 셰이더는 URP Lit 셰이더를 기반으로 하여 제작되었습니다

Lit 셰이더에서 할 수 없었던 레디언스 제어, 스펙큘러 제어, 프레넬 제어 등을 할 수 있고, 

브러시 텍스처를 통하여 다양한 스타일라이즈한 느낌을 추가할 수 있습니다

즉, PBR의 속성을 전부 사용하면서도 조금 더 만화같은 표현을 하기에 적합한 셰이더라고 할 수 있겠습니다

![image](https://user-images.githubusercontent.com/35050187/100261210-c19b3280-2f8d-11eb-9b87-2c3fad0f5d54.png)

레디언스 제어가 가능하기 때문에 이처럼 NPR 느낌도 잘 소화합니다 


![image](https://user-images.githubusercontent.com/35050187/100261302-e5f70f00-2f8d-11eb-8a63-45a11901120d.png)

프로젝트 첫 화면은 위와 같습니다 

![image](https://user-images.githubusercontent.com/35050187/100262276-463a8080-2f8f-11eb-935a-b5830208bfd0.png)

인스펙터 화면입니다. 

Lit 셰이더와 비슷하지만 Advance 항목을 클릭하면 Stylized Lit 셰이더만의 옵션이 추가로 보이게 됩니다

![image](https://user-images.githubusercontent.com/35050187/100262538-9fa2af80-2f8f-11eb-8157-e83b15d12f56.png)

Stylized Diffuse 에서는 3가지의 컬러와 Threshold, Smooth를 이용하여 표면의 라이팅을 리매핑하게 됩니다

위 이미지에서 알 수 있듯이 Lambert LightModel을 이용하여 프로시졀하게 Ramp Texture를 만드는 방식이라고 생각하시면 될듯합니다 

![image](https://user-images.githubusercontent.com/35050187/100262768-f6a88480-2f8f-11eb-9cd3-c2b126d695a9.png)

Stylized Reflection에서는 Specular와 Fresnel을 추가로 제어할 수 있고, Metal의 큐브맵 밝기와 NonMetal의 큐브맵 밝기를 따로 제어할 수 있습니다 



![image](https://user-images.githubusercontent.com/35050187/100262679-d5479880-2f8f-11eb-8a71-8efc0b407eaa.png)


Stylized Lit 셰이더의 가장 큰 특징중에 또 한가지는 브러시 텍스처를 사용할 수 있다는 것입니다

![image](https://user-images.githubusercontent.com/35050187/100262018-ef34ab80-2f8e-11eb-8654-9a2ac7743afd.png)

브러시 텍스처는 위처럼 제작하면 되고, 각각
R채널은 Med Tone,
G채널은 Shadow,
B채널은 Reflect 에 대응합니다 

샘플링을 아끼기 위해 타일링은 공통으로 쓸 수밖에 없으니 텍스처를 만들때 계획적으로 만들어 사용해 주세요

![image](https://user-images.githubusercontent.com/35050187/100261554-4423f200-2f8e-11eb-9364-0b35c4d1f1bf.png)

브러시텍스처 적용 사례에 대해서 간단하게 정리해보았습니다 


이 셰이더의 사용은 자유롭습니다

상용프로젝트에서 사용하신다면 메일이라도 하나 남겨주시면 감사드리겠습니다 (별을 찍어주셔도 좋습니다) 

메일주소는 mnpshino@gmail.com 입니다

감사합니다

---------------------------------------------------
Version 1.1

![image](https://user-images.githubusercontent.com/35050187/105962483-39d3c080-60c3-11eb-9ebe-11c612051d4b.png)

1.1버전에서는 실시간그림자를 Shadow Color 계산에 포함하는 것으로 수정하였습니다

실시간 그림자와 암부 계산을 한번에 하여 Shadow Smooth로 실시간 그림자 경계까지 한번에 컨트롤 하는것이 가능해졌습니다 


또한 GI(Indirect Diffuse)의 밝기를 컨트롤 할 수 있는 GI Intensity 기능이 추가 되었습니다 


----------------------------------------------------
Version 1.2

![2020_3_newFeature](https://user-images.githubusercontent.com/35050187/122582888-a0b63e00-d093-11eb-9a76-c9135392cd18.gif)

1.2 버전에서는 2020.3이상버전을 지원하며, 뎁스노멀패스가 추가되어 SSAO를 사용할 수 있게 되었습니다.

또한 GGX Specular와 Stylized Specular를 선택할 수 있게 되었습니다. 

그리고 Directional Fresnel기능이 추가되어, 암부에서 들어오는 프레넬을 Occlusion할 수 있게 되었습니다. 



----------------------------------------------------
  
추가 -

패키지 매니저를 통한 다운로드 방법 (컴퓨터에 Git이 설치되어 있어야 합니다) 

1. URP 세팅이 된 프로젝트를 열어주세요.
없는 경우 빈 URP 템플릿의 프로젝트를 생성해도 됩니다.

2. 유니티 에디터 상단 메뉴아이템에서 패키지 매니저를 열어주세요.
`Window` - `Package Manager`  
  
3. ` + ` 버튼을 눌러 Add package from git URL... 을 선택해주세요.
```
https://github.com/madumpa/URP_StylizedLitShader.git#packageManagerWork
```
을 붙여넣습니다.

![Image](https://github.com/madumpa/URP_StylizedLitShader/raw/packageManagerWork/Images~/git.png)

4. 설치가 완료되면 Samples 탭을 열어 Demo Assets를 Import 합니다.  
  
![Image](https://github.com/madumpa/URP_StylizedLitShader/raw/packageManagerWork/Images~/samples.png)
  
5. 프로젝트 뷰에 생긴 데모 에셋 폴더의 데모 씬을 엽니다.  

![Image](https://github.com/madumpa/URP_StylizedLitShader/raw/packageManagerWork/Images~/project.png)
