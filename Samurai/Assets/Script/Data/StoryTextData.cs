using System.Collections.Generic;

public static class StoryDatabase
{
    public const string VILLAGE_FRIEND_1 = "village_friend_1";
    public const string VILLAGE_FRIEND_2 = "village_friend_2";
    public const string VILLAGE_FRIEND_3 = "village_friend_3";
    public const string VILLAGE_FRIEND_4 = "village_friend_4";
    public const string VILLAGE_FRIEND_5 = "village_friend_5";
    public const string VILLAGE_FRIEND_6 = "village_friend_6";
    public const string VILLAGE_FRIEND_7 = "village_friend_7";
    public const string VILLAGE_FRIEND_8 = "village_friend_8";
    public const string VILLAGE_FRIEND_9 = "village_friend_9";
    public const string VILLAGE_FRIEND_10 = "village_friend_10";
    public const string VILLAGE_FRIEND_11 = "village_friend_11";
    public const string VILLAGE_FRIEND_12 = "village_friend_12";
    public const string VILLAGE_FRIEND_13 = "village_friend_13";
    public const string VILLAGE_FRIEND_14 = "village_friend_14";
    public const string VILLAGE_FRIEND_15 = "village_friend_15";
    public const string VILLAGE_FRIEND_16 = "village_friend_16";
    public const string VILLAGE_FRIEND_17 = "village_friend_17";
    public const string VILLAGE_FRIEND_18 = "village_friend_18";
    public const string VILLAGE_FRIEND_19 = "village_friend_19";
    public const string VILLAGE_FRIEND_20 = "village_friend_20";


    public const string VILLAGE_TEACHER_1 = "village_teacher_1";
    public const string VILLAGE_TEACHER_2 = "village_teacher_2";
    public const string VILLAGE_TEACHER_3 = "village_teacher_3";
    public const string VILLAGE_TEACHER_4 = "village_teacher_4";
    public const string VILLAGE_TEACHER_5 = "village_teacher_5";
    public const string VILLAGE_TEACHER_6 = "village_teacher_6";
    public const string VILLAGE_TEACHER_7 = "village_teacher_7";
    public const string VILLAGE_TEACHER_8 = "village_teacher_8";
    public const string VILLAGE_TEACHER_9 = "village_teacher_9";
    public const string VILLAGE_TEACHER_10 = "village_teacher_10";
    public const string VILLAGE_TEACHER_11 = "village_teacher_11";
    public const string VILLAGE_TEACHER_12 = "village_teacher_12";
    public const string VILLAGE_TEACHER_13 = "village_teacher_13";
    public const string VILLAGE_TEACHER_14 = "village_teacher_14";
    public const string VILLAGE_TEACHER_15 = "village_teacher_15";
    public const string VILLAGE_TEACHER_16 = "village_teacher_16";
    public const string VILLAGE_TEACHER_17 = "village_teacher_17";
    public const string VILLAGE_TEACHER_18 = "village_teacher_18";
    public const string VILLAGE_TEACHER_19 = "village_teacher_19";
    public const string VILLAGE_TEACHER_20 = "village_teacher_20";


    public static readonly Dictionary<string, List<Dialogue>> Stories = new()
    {

        // 친구
        [VILLAGE_FRIEND_1] = new List<Dialogue>()
        {
            // 마을 첫 장면
            new Dialogue("친구", "...이봐! 정신이 좀 드나? 땀을 이렇게나 흘리고... 또 그 악몽에 시달린 거야?"),
            new Dialogue("주인공", "...불타는 사원 한복판에서... 너와 스승님이 피투성이가 된 채 내 발치에 쓰러지는 꿈이었다."),
            new Dialogue("주인공", "그 잿더미 속에서... 내 손에는 붉게 물든 검이 쥐어져 있었어. 내가 너희를 베어넘긴 것처럼..."),
            new Dialogue("친구", "꿈은 현실과 반대라고 하잖아. 난 이렇게 멀쩡히 서 있는데 무슨 소릴 하는 거야. 얼굴빛이 종이처럼 하얗다고."),
            new Dialogue("주인공", "...단순한 악몽이 아닌 것 같다. 가슴 밑바닥에서... 알 수 없는 거친 살의와 죄책감이 동시에 솟구쳐 오르고 있어."),
            new Dialogue("친구", "요즘 너무 지쳐서 마음이 불안한 것뿐이야. 스승님께서 기다리고 계셔. 얼른 가 봐.")
        },

        [VILLAGE_FRIEND_2] = new List<Dialogue>()
        {
            // 1챕터 Stage 1 클리어 후 - 친구 대화
            new Dialogue("친구", "혼자 숲으로 떠나서 얼마나 걱정했는지 몰라! 무사히 돌아와서 정말 다행이다. 첫 싸움은 어땠어?"),
            new Dialogue("주인공", "...몸은 무사하다. 하지만 이상하게도... 검이 적의 몸을 베어 가를 때마다 가슴 한구석이 통증으로 비명을 지르는 듯했어."),
            new Dialogue("주인공", "베어진 자들의 눈빛에서 나를 향한 깊은 원망과 절규가 느껴졌다. 손끝이 덜덜 떨릴 정도로..."),
            new Dialogue("친구", "오랜만의 실전이라 긴장해서 잔상이 남은 걸 거야. 넌 사원을 지키는 일을 한 거라고! 어서 스승님께 가 봐, 기다리셔.")
        },

        [VILLAGE_FRIEND_3] = new List<Dialogue>()
        {
            // 1챕터 Stage 4 클리어 후 - 친구 대화
            new Dialogue("친구", "이제 곧 홀로 숲 가장 깊은 곳의 우두머리와 싸우러 가는 거지? ...너, 얼굴빛이 왜 그렇게 유령처럼 차가워? 진짜 괜찮은 거야?"),
            new Dialogue("주인공", "...친구여. 내가 베어넘긴 수많은 적들의 얼굴이, 쓰러지며 남긴 마지막 말이... 자꾸만 내 기억 속 사람들과 겹쳐 보인다."),
            new Dialogue("주인공", "내가 베어내고 있는 것이... 정말 사원을 위협하는 '적'이 맞기는 한 걸까?"),
            new Dialogue("친구", "무... 무슨 소리를 하는 거야! 넌 사원과 우리를 지키기 위해 싸우는 거라고! 더 이상 이상한 소리 하지 마!"),
            new Dialogue("친구", "얼른 스승님께 가 봐. 수련을 완수해야 이 악몽도 끝날 거 아니야... 얼른!")
        },

        [VILLAGE_FRIEND_4] = new List<Dialogue>()
        {
            // 1챕터 Stage 5 클리어 후 - 친구 대화
            new Dialogue("친구", "혼자서 대나무 숲의 우두머리를 물리치고 오다니! 무사히 해냈구나, 정말 장해! 이제 숲의 위협도 한시름 놓았어."),
            new Dialogue("주인공", "...친구여. 우두머리를 베어 넘겼을 때, 녀석의 눈빛은 적의가 아니라 슬픔으로 차 있었다."),
            new Dialogue("주인공", "그 녀석이 쓰러지며 내 손을 잡으려 했어... 그리고 내 이름을 불렀다. 도대체 나한테 무슨 일이 일어나고 있는 걸까?"),
            new Dialogue("주인공", "...그리고 너는 왜 아까부터 손을 그렇게 경련하듯 떨고 있는 건가? 땀마저 흐르고 있잖아."),
            new Dialogue("친구", "아... 아무것도 아니야! 바람이 차서... 그냥 몸이 좀 떨린 것뿐이라고! 이상한 질문 좀 그만해!"),
            new Dialogue("친구", "어서 스승님을 뵈러 가! 다음 지역으로 가라고 하실 거 아니야! 얼른!")
        },

        [VILLAGE_FRIEND_5] = new List<Dialogue>()
        {
            // 2챕터 Stage 1 클리어 후 - 친구 대화
            new Dialogue("친구", "참나무 숲으로 혼자 떠났을 때 얼마나 걱정했는지 몰라... 무사히 돌아왔구나! 숲 내부 분위기는 어땠어?"),
            new Dialogue("주인공", "...친구여. 참나무 숲 깊은 곳에서 베어 넘긴 적의 품에서... 핏빛으로 물든 노리개가 떨어졌다."),
            new Dialogue("주인공", "내가 어릴 적 우리 마을 아이에게 직접 만들어주었던 것과 똑같은 형태였어. 대체 그 기괴한 적의 손에 왜 이게 있었던 걸까?"),
            new Dialogue("친구", "그, 그건 그냥 흔한 장식품이겠지! 그 괴물들이 어디선가 주운 걸 수도 있잖아! 제발 이상하게 생각하지 마..."),
            new Dialogue("친구", "스승님께서 본당에서 기다리고 계셔. 얼른 가서 경과를 보고해 봐.")
        },

        [VILLAGE_FRIEND_6] = new List<Dialogue>()
        {
            // 2챕터 Stage 4 클리어 후 - 친구 대화
            new Dialogue("친구", "홀로 무사히 돌아왔구나... 그런데 너, 얼굴빛이 왜 이렇게 하얗게 질려 있어? 몸도 심하게 떨리고 있잖아..."),
            new Dialogue("주인공", "...친구여. 숲 깊은 곳에서 적들을 베어넘기며 전진하다가... 눈앞에 펼쳐진 광경을 똑똑히 보았다."),
            new Dialogue("주인공", "우리가 헤쳐나가고 있는 이 숲길 전체가... 저 멀리 거대한 폭포가 보이는 마을로 이어진 길이었어."),
            new Dialogue("주인공", "내가 방금 베어넘긴 자는... 폭포 마을 입구에서 날 향해 손을 뻗던 노인이었다. 도대체 우리가 왜 그들의 마을로 향하는 길목에서 이 피비린내 나는 짓을 하고 있는 거냐?!"),
            new Dialogue("친구", "이, 이상한 소리 하지 마! 환각이라니까! 스승님께서 분명 사원을 침범하려는 괴물들이라고 하셨잖아! 제발 깊게 생각하지 마..."),
            new Dialogue("친구", "스승님께 가 봐... 얼른 우두머리를 처치하고 이 악몽을 끝내라고 하실 거야! 어서!")
        },

        [VILLAGE_FRIEND_7] = new List<Dialogue>()
        {
            // 2챕터 Stage 5 클리어 후 - 친구 대화
            new Dialogue("친구", "숲의 우두머리마저 홀로 제압하고 오다니... 정말 대단해! 무사히 돌아와서 천만다행이야."),
            new Dialogue("주인공", "...친구여. 숲길의 끝, 우두머리를 단죄하고 난 뒤 펼쳐진 광경을 보았다."),
            new Dialogue("주인공", "우리가 지나온 이 길 전체가... 저 멀리 거대한 폭포가 보이는 마을로 이어지는 길이었어. 바로 우리들의 고향 말이다."),
            new Dialogue("주인공", "스승님은 사원을 지키기 위해 적을 단죄하라고 하셨지만, 어째서 우리가 베어낸 적들의 자취가 전부 그 폭포 마을을 향하고 있는 거냐!"),
            new Dialogue("친구", "나, 나한테 소리 지르지 마! 난 아무것도 몰라! 다, 다 스승님이... 사원을 위해 해야만 하는 일이라고 하셨단 말이야!"),
            new Dialogue("친구", "더, 더 알고 싶으면 스승님한테 직접 물어봐! 난 아무것도 몰라!")
        },

        [VILLAGE_FRIEND_8] = new List<Dialogue>()
        {
            // 3챕터 Stage 1 클리어 후 - 친구 대화
            new Dialogue("친구", "결국 스승님 말씀대로 그 폭포 마을 내부까지 혼자 들어갔다 온 거야...? 무사해서 다행이긴 한데... 표정이 왜 그래?"),
            new Dialogue("주인공", "...친구여. 폭포 마을은 악귀들의 소굴 따위가 아니었다. 핏빛으로 물든 처참한 폐허... 그곳에 있던 건 그저 울부짖는 마을 사람들이었어."),
            new Dialogue("주인공", "내가 검을 휘두를 때마다 폭포수가 핏빛으로 번져갔다. 우리가 어린 시절 같이 놀던 그 폭포 밑에서... 내가 무슨 짓을 저지른 건지 아느냐!"),
            new Dialogue("친구", "그, 그건 다 환상이라고 스승님이 말씀하셨잖아! 폭포 마을은 이미 마기에 삼켜진 적들의 거점이야! 제발 현실을 봐!"),
            new Dialogue("친구", "난 몰라... 난 스승님 말씀을 믿을 거야! 더 이상 그런 불길한 말 하지 말고 스승님께 가 봐!")
        },

        [VILLAGE_FRIEND_9] = new List<Dialogue>()
        {
            // 3챕터 Stage 4 클리어 후 - 친구 대화
            new Dialogue("친구", "홀로 무사히 돌아오긴 했는데... 너 꼴이 그게 뭐야?! 피비린내가 진동을 하고, 눈빛은 완전히 제정신이 아니잖아!"),
            new Dialogue("주인공", "...친구여. 이제 모든 게 확실해졌다. 스승님이 말씀하신 '적의 거점'은 그저 매일 폭포 소리를 들으며 평화롭게 살아가던 우리 마을이었다."),
            new Dialogue("주인공", "아까 날 향해 죽어가며 손을 뻗은 건... 내가 베어넘긴 건... 내 이웃이자 동료들이었다! 나와 함께 웃던 자들이란 말이다!"),
            new Dialogue("친구", "아, 아니야... 거짓말이지? 네가 환각을 보고 있는 거라고 해줘, 제발! 날 그렇게 무서운 눈으로 보지 마...!"),
            new Dialogue("친구", "스승님께 가... 스승님이 다 설명해주실 거야! 난 몰라, 아무것도 듣고 싶지 않아!")
        },

        [VILLAGE_FRIEND_10] = new List<Dialogue>()
        {
            // 3챕터 Stage 5(폭포 마을 우두머리) 클리어 후 - 친구 대화
            new Dialogue("친구", "...폭포 마을의 우두머리마저, 정말 끝내고 돌아온 거야? 근데... 손에 쥔 그건 뭐야?"),
            new Dialogue("주인공", "...친구여. 방금 벤 것은 사람이 아니었다. 낡은 옷가지와 빛바랜 노리개, 핏자국이 엉겨 붙은 유품들뿐이었어."),
            new Dialogue("주인공", "내가 지금껏 베어온 게... 처음부터 아무것도 없었던 걸까. 아니면 이미 오래전에 끝난 무언가를... 나 혼자 반복하고 있었던 걸까."),
            new Dialogue("친구", "(형체가 지지직거리며 크게 흔들린다) ...그만해. 제발 그만해. 더는 아무것도 묻지 마..."),
            new Dialogue("친구", "...나는 그저, 네가 조금이라도 덜 아프길 바랐을 뿐이야. 그게... 그렇게 잘못된 거였을까."),
            new Dialogue("주인공", "...무슨 말을 하는 거지, 친구여?"),
            new Dialogue("친구", "...아니야, 아무것도. 스승님께 가 봐. 이제 정말... 얼마 남지 않았으니까.")
        },

        [VILLAGE_FRIEND_11] = new List<Dialogue>()
        {
            // 불타는 마을 - 친구의 잔향 등장 (최종장 2관문)
            new Dialogue("친구", "...스승님 말씀, 다 들었지."),
            new Dialogue("주인공", "...친구여. 너도, 나에게 거짓을 말했던 건가."),
            new Dialogue("친구", "거짓이 아니야. 그저 네가 조금이라도 더 버틸 시간이 필요했을 뿐이야."),
            new Dialogue("친구", "하지만 그 시간도 이제 다 됐어. 더는... 도망칠 곳이 없어."),
            new Dialogue("주인공", "...도망친 게 아니다! 나는 그저, 믿고 싶었을 뿐이야. 너희가 살아 있다고!"),
            new Dialogue("친구", "(피눈물을 흘리며 검을 뽑아 든다) 알아. 그러니까 이제 내가, 끝까지 데려다줄게."),
            new Dialogue("친구", "네 손으로 직접 확인해. 내가 정말 네 친구인지, 아니면 네가 놓지 못한 미련일 뿐인지."),
            new Dialogue("주인공", "...!"),
            new Dialogue("친구", "자, 덤벼. 이게 마지막이야.")
        },

        [VILLAGE_FRIEND_12] = new List<Dialogue>()
        {
            // 최종 보스전 종료 후 - 엔딩
            new Dialogue("친구", "(무릎을 꿇으며) ...아. 드디어, 끝났구나."),
            new Dialogue("주인공", "...미안하다. 미안해..."),
            new Dialogue("친구", "미안해하지 마. 오히려... 고마워."),
            new Dialogue("친구", "이 오랜 잔향 속에서도, 결국 진짜 나를 봐줘서. 도망치지 않고 여기까지 와줘서."),
            new Dialogue("주인공", "...가지 마. 제발, 가지 마..."),
            new Dialogue("친구", "네가 우리 몫까지 살아야, 그래야 이 잔향도 진짜 끝나는 거야. 이제... 눈을 떠."),
            new Dialogue("친구", "(빛의 잔재처럼 흩어지며 완전히 사라진다)"),
            new Dialogue("주인공", "......"),
            new Dialogue("주인공", "(피눈물을 흘리며, 잿더미가 된 마을 한복판에 홀로 무릎을 꿇는다)")
        },

        [VILLAGE_FRIEND_13] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_14] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_15] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_16] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_17] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_18] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_19] = new List<Dialogue>() { },
        [VILLAGE_FRIEND_20] = new List<Dialogue>() { },


        //스승
        [VILLAGE_TEACHER_1] = new List<Dialogue>()
        {
            // 사원 본당 - 스승과의 첫 대화
            new Dialogue("스승", "눈빛이 붉게 젖어 있구나. 본당에 들어설 때부터 거친 숨소리와 음산한 기운이 여기까지 느껴진다."),
            new Dialogue("주인공", "...스승님. 제 내면의 소용돌이를 다스릴 수가 없습니다. 억눌러온 검기가... 제 의지와 상관없이 폭주하려 합니다."),
            new Dialogue("스승", "마음의 균형이 깨지면 결국 검이 주인을 휘두르고, 내면의 깊은 어둠이 너를 집어삼키는 법이니라."),
            new Dialogue("스승", "당장 마당으로 가거라. 분노가 아닌 칼날의 감각과 순수한 호흡에 집중하여 심상을 가다듬고 오거라."),
            new Dialogue("주인공", "...예, 스승님. 잡념을 털어내고 내면의 살기를 가라앉힌 뒤 다시 올리겠습니다.")
        },

        [VILLAGE_TEACHER_2] = new List<Dialogue>()
        {
            // 사원 본당 - 심상 수련 완료 후 첫 퀘스트 수령
            new Dialogue("주인공", "...스승님, 호흡을 바로잡았습니다. 칼끝의 감각을 세우며... 폭주하던 마음을 조금은 다스렸습니다."),
            new Dialogue("스승", "좋다. 칼끝의 미세한 떨림이 비로소 안정을 찾았구나. 분노에 안개를 씌우지 않는 것이 검사의 기본이다."),
            new Dialogue("스승", "하지만 방심하긴 이르다. 최근 사원 외곽의 대나무 숲에 정체불명의 적들이 침입했다는 기괴한 소문이 들린다."),
            new Dialogue("주인공", "사원을 노리는 적들입니까... 제 검으로 즉시 단죄하겠습니다."),
            new Dialogue("스승", "숲으로 나아가라. 네 칼날이 사사로운 정에 흔들리지 않음을 실전에서 증명하고 오거라."),
            new Dialogue("주인공", "명심하겠습니다. 사원의 평화를 어지럽히는 무리를 모두 소탕하고 돌아오겠습니다.")
        },

        [VILLAGE_TEACHER_3] = new List<Dialogue>()
        {
            // 1챕터 Stage 1 클리어 후 - 스승 대화
            new Dialogue("스승", "홀로 첫 번째 실전을 치르고 돌아왔구나. 하지만 네 눈빛을 보니 여전히 칼끝에 자비와 망설임이 서려 있다."),
            new Dialogue("주인공", "...스승님. 적을 베어넘길 때마다 가슴속에서 알 수 없는 죄책감과 슬픔이 솟구쳐 올랐습니다. 그들은 대체 누구입니까?"),
            new Dialogue("스승", "네 안의 사악한 마기가 정념을 어지럽혀 환상을 만들어내는 것이다. 마음을 비우지 못하면 네 검이 먼저 부러질 것이다."),
            new Dialogue("스승", "다시 숲으로 나가라. 대나무 숲 깊은 곳으로 더 파고들어 사원을 엿보는 자들을 단죄하고, 마음의 흔들림을 털어내라.")
        },

        [VILLAGE_TEACHER_4] = new List<Dialogue>()
        {
            // 1챕터 Stage 2 클리어 후 - 스승 대화
            new Dialogue("스승", "혼자서 또 한 번의 수련을 마치고 돌아왔구나. 네 칼 끝에 묻어나는 기운이 이전보다 한층 더 무겁고 짙어졌느니라."),
            new Dialogue("주인공", "...스승님. 억지로 검을 휘두르다 보니... 점차 가슴을 짓누르던 죄책감도, 손끝의 감각도 무뎌져 가는 기분입니다."),
            new Dialogue("주인공", "피비린내 속에서 점점 감정을 잃어가는 제 모습이... 때로는 무섭게 느껴집니다."),
            new Dialogue("스승", "사사로운 감정을 털어내고 냉정해지는 것이 바로 무도(武道)의 길이자, 사원을 지키는 검사의 운명이다."),
            new Dialogue("스승", "멈추지 마라. 홀로 숲으로 나아가 가시밭길을 헤치며 네 내면의 찌꺼기를 모두 태워버리거라.")
        },

        [VILLAGE_TEACHER_5] = new List<Dialogue>()
        {
            // 1챕터 Stage 3 클리어 후 - 스승 대화
            new Dialogue("스승", "또 한 번 승전보를 가져왔구나. 호흡과 검의 궤적이 한결 단정해진 것이, 이제야 제법 망설임 없는 검사의 기틀이 보이는구나."),
            new Dialogue("주인공", "...스승님, 감각은 또렷해졌으나 환각이 심해지고 있습니다. 적들이 쓰러지며 내뱉는 비명이..."),
            new Dialogue("주인공", "마치 오랫동안 저를 알고 지내던 사원 사람들의 절규처럼 귓가를 찢어발깁니다. 숲의 안개마저 핏빛으로 보입니다."),
            new Dialogue("스승", "네 마음의 약함과 죄책감이 빚어낸 환상에 불과하다. 의지를 더욱 굳건히 하여 잔향에 마음을 빼앗기지 마라."),
            new Dialogue("스승", "숲의 깊은 안개 속으로 더 나아가라. 마기를 집어삼키며 허상을 베어내는 의지를 증명해라.")
        },

        [VILLAGE_TEACHER_6] = new List<Dialogue>()
        {
            // 1챕터 Stage 4 클리어 후 - 스승 대화
            new Dialogue("스승", "마침내 홀로 대나무 숲의 가장 깊은 안개 속, 그 근원 앞까지 도달했구나."),
            new Dialogue("주인공", "...스승님. 숲 저 깊은 안개 너머에서 차가운 살기와 함께 나를 짓누르는 참담한 원망이 느껴집니다."),
            new Dialogue("스승", "대나무 숲을 지배하며 온갖 기괴한 환영과 기운을 퍼뜨리는 우두머리가 기다리고 있다."),
            new Dialogue("스승", "망설임 없이 홀로 나아가 그자의 목을 베어 수련을 완수해라. 그 거대한 잔향을 끊어내야 네 검이 비로소 완성될 것이다.")
        },

        [VILLAGE_TEACHER_7] = new List<Dialogue>()
        {
            // 1챕터 Stage 5 클리어 후 - 스승 대화 (2챕터 전환)
            new Dialogue("스승", "대나무 숲의 우두머리를 베어넘기고 마침내 첫 번째 시련을 넘어섰구나. 장하다."),
            new Dialogue("주인공", "...스승님. 우두머리가 쓰러지며 내뱉은 마지막 유언이... 마치 오랫동안 저를 깊이 아끼고 걱정해 주던 사람의 목소리였습니다."),
            new Dialogue("주인공", "이 괴로움이... 정말 단지 제 마음이 약해서 생기는 환각일 뿐입니까? 제 손에 묻은 피가 너무나도 차갑게 느껴집니다."),
            new Dialogue("스승", "마기에 짓눌린 칼날과 네 죄책감이 만들어낸 지독한 잔향일 뿐이다. 동요하는 순간 네 영혼마저 침식될 것이다."),
            new Dialogue("스승", "돌아보지 마라. 이제 다음 지역인 '참나무 숲'으로 홀로 이동하여, 그곳을 오염시키는 마물을 베어 넘기고 칼날을 더욱 날카롭게 다스려라.")
        },

        [VILLAGE_TEACHER_8] = new List<Dialogue>()
        {
            // 2챕터 Stage 1 클리어 후 - 스승 대화
            new Dialogue("스승", "참나무 숲으로 단신으로 나아가 첫 전투를 치르고 왔구나. 하지만 네 눈동자 속 혼란은 더욱 짙어졌군."),
            new Dialogue("주인공", "...스승님. 쓰러뜨린 적의 품에서 우리 마을의 흔적을 발견했습니다. 사원을 위협하는 악귀라기엔 너무나도..."),
            new Dialogue("스승", "사악한 무리는 네 마음을 약하게 만들기 위해 환영과 거짓된 물건으로 너를 현혹하려 하는 법이다."),
            new Dialogue("스승", "눈앞의 현상에 흔들리지 마라. 다시 참나무 숲으로 홀로 들어가 칼을 가누고 사사로운 잡념을 끊어내라.")
        },

        [VILLAGE_TEACHER_9] = new List<Dialogue>()
        {
            // 2챕터 Stage 2 클리어 후 - 스승 대화
            new Dialogue("스승", "참나무 숲 깊은 곳에서 홀로 두 번째 토벌을 마치고 돌아왔구나. 네 칼끝의 피비린내가 점차 기괴하게 짙어지고 있다."),
            new Dialogue("주인공", "...스승님. 숲 깊은 곳에서 베어넘긴 무리 중 하나가 쓰러지며 제 발치에 절을 하듯 엎드렸습니다."),
            new Dialogue("주인공", "그자는 죽어가는 순간까지도 검을 빼들지 않고... 그저 저를 향해 눈물을 흘리며 살려달라 손을 뻗었습니다. 악귀가 어찌 이런 행동을 한단 말입니까?"),
            new Dialogue("스승", "사악한 마물일수록 검사의 동정심을 자극하여 목숨을 구걸하는 뱀 같은 간계에 능한 법이다."),
            new Dialogue("스승", "동요하지 마라. 네가 헛된 동정심으로 칼을 거두는 순간, 그 칼날은 사원과 네 동료들의 목을 찌를 것이다."),
            new Dialogue("스승", "다시 참나무 숲으로 홀로 나아가라. 깊숙이 걸어 들어가 네 안의 쓸데없는 연민을 완전히 베어내거라.")
        },

        [VILLAGE_TEACHER_10] = new List<Dialogue>()
        {
            // 2챕터 Stage 3 클리어 후 - 스승 대화
            new Dialogue("스승", "세 번째 토벌을 끝내고 돌아왔구나. 허나 네 눈빛은 이전보다 더욱 아득하게 흔들리고 있군."),
            new Dialogue("주인공", "...스승님. 피비린내 사이로 자꾸만 마을 향나무 향이 풍깁니다. 숲속을 떠도는 괴물들의 비명 역시..."),
            new Dialogue("주인공", "마치 이 사원의 식구들이 제발 그만해 달라고 애원하는 소리로 귓전을 때립니다. 제 정신이 온통 미쳐가는 것 같습니다."),
            new Dialogue("스승", "네 검기가 날카로워질수록 환영의 저항 또한 거세지는 것이다. 마기가 네 마음을 집어삼키려 안간힘을 쓰는 게지."),
            new Dialogue("스승", "환각 따위에 마음을 빼앗기지 마라. 참나무 숲 깊은 곳으로 더 파고들어 내면의 마수를 계속해서 단죄해라.")
        },

        [VILLAGE_TEACHER_11] = new List<Dialogue>()
        {
            // 2챕터 Stage 4 클리어 후 - 스승 대화
            new Dialogue("스승", "마침내 적들이 사원으로 몰려오는 길목의 가장 깊은 근원 바로 앞까지 홀로 다다랐구나."),
            new Dialogue("주인공", "...스승님. 제발 사실대로 말씀해 주십시오. 우리가 헤쳐온 이 길의 끝은 적의 굴이 아니라... 저 폭포가 보이는 마을이었습니다."),
            new Dialogue("주인공", "어째서 우리가 베어넘기는 적들이 그 폭포 마을로 향하는 길목을 막아서며 눈물을 흘리고 있는 것입니까?"),
            new Dialogue("스승", "네 마음속 마기가 깊어져 환영이 진실의 탈을 쓰고 너를 희롱하는 것이다. 진입로의 끝을 앞두고 동요하지 마라."),
            new Dialogue("스승", "폭포 마을 방면에서 몰려드는 거짓의 근원, 그 우두머리를 홀로 단죄해라. 그자의 목을 베어 넘겨야 사원으로 향하는 흉악한 길목이 닫힐 것이다.")
        },

        [VILLAGE_TEACHER_12] = new List<Dialogue>()
        {
            // 2챕터 Stage 5 클리어 후 - 스승 대화 (3챕터 전환)
            new Dialogue("스승", "숲의 우두머리를 거두고 시련을 넘어섰구나. 허나 네 눈빛에는 여전히 불길한 의구심이 서려 있군."),
            new Dialogue("주인공", "스승님! 더 이상 저를 현혹하지 마십시오! 우리가 헤쳐온 이 길은 적의 베이스... 저 폭포가 보이는 마을로 향하는 길이었습니다!"),
            new Dialogue("주인공", "그곳이 어째서 악귀들의 본거지라는 말입니까?!"),
            new Dialogue("스승", "마기가 사원의 젖줄이었던 폭포 마을을 통째로 삼켜버렸기 때문이다. 네가 거쳐온 길은 그 악귀들이 사원으로 침범하던 길목이었을 뿐이다."),
            new Dialogue("스승", "네가 주저하는 동안에도 폭포 마을의 마물들은 사원을 노리고 있다."),
            new Dialogue("스승", "의구심을 거두어라. 이제 진입로를 넘어 적의 본거지인 '폭포 마을'로 홀로 들어가, 침입을 준비하는 무리를 단죄해라.")
        },

        [VILLAGE_TEACHER_13] = new List<Dialogue>()
        {
            // 3챕터 Stage 1 클리어 후 - 스승 대화
            new Dialogue("스승", "적의 본거지인 폭포 마을에 홀로 발을 들여 첫 단죄를 마치고 돌아왔구나. 하지만 네 눈은 당장이라도 무너질 듯 불안하군."),
            new Dialogue("주인공", "...스승님. 제 눈으로 똑똑히 보았습니다. 그곳은 악귀들의 베이스가 아닙니다! 그저 붉은 피를 흘리며 도망치는 우리 마을 사람들이었습니다!"),
            new Dialogue("스승", "어리석은 놈. 마기가 빚어낸 지독한 환영에 완전히 정신을 빼앗겼구나. 그곳이 바로 사원을 위협하는 악의 근원이다."),
            new Dialogue("스승", "헛된 망상으로 칼날을 둔하게 만들지 마라. 다시 폭포 마을 깊숙이 홀로 들어가 마물을 베어내고 마음의 저항을 끊어내라.")
        },

        [VILLAGE_TEACHER_14] = new List<Dialogue>()
        {
            // 3챕터 Stage 2 클리어 후 - 스승 대화
            new Dialogue("스승", "폭포 마을 내부에서 홀로 두 번째 단죄를 마치고 돌아왔구나. 네 칼 끝에 묻은 핏빛이 이제 온 몸을 물들일 기세다."),
            new Dialogue("주인공", "...스승님. 베어 넘긴 적들이 쓰러지며 지른 마지막 비명 속에서... 제 이름을 부르는 소리를 들었습니다."),
            new Dialogue("주인공", "폭포 소리마저 찢어발기는 그 통곡 속에서 그들은 저를 악귀라 부르며 눈을 감았습니다. 제가 정녕 사원을 지키는 자가 맞습니까?"),
            new Dialogue("스승", "마물들이 죽어가는 순간까지 네 영혼을 삼키기 위해 뱉어내는 지독한 주술일 뿐이다."),
            new Dialogue("스승", "네가 칼날을 세우지 않으면 그 기괴한 기운이 폭포 마을을 넘어 이 사원까지 잿더미로 만들 것이다."),
            new Dialogue("스승", "흔들리지 말고 다시 폭포 마을로 홀로 나아가라. 핏빛의 환영을 단죄하여 내면의 허상을 베어내거라.")
        },

        [VILLAGE_TEACHER_15] = new List<Dialogue>()
        {
            // 3챕터 Stage 3 클리어 후 - 스승 대화
            new Dialogue("스승", "폭포 마을에서 세 번째 토벌을 마치고 돌아왔구나. 허나 네 눈빛은 이미 깊은 혼란에 빠져 미쳐가고 있군."),
            new Dialogue("주인공", "...스승님. 피로 물든 폭포가 비치는 물웅덩이에 제 모습이 비쳤습니다. 그 속에 서 있는 것은 검사가 아니라... 피에 굶주린 한 마리의 악귀였습니다."),
            new Dialogue("주인공", "내가 베어넘긴 수많은 사람들의 피가 폭포수가 되어 제 몸을 적시고 있습니다. 가슴이... 가슴이 찢어질 것처럼 아픕니다!"),
            new Dialogue("스승", "네 안의 사악한 환영이 마침내 네 영혼을 완전히 침식하려 하는구나. 여기서 물러서면 너는 진짜 마물이 될 뿐이다."),
            new Dialogue("스승", "눈을 감고 검을 믿어라. 다시 폭포 마을 깊은 곳으로 홀로 파고들어 마기의 뿌리를 잘라내라.")
        },

        [VILLAGE_TEACHER_16] = new List<Dialogue>()
        {
            // 3챕터 Stage 4 클리어 후 - 스승 대화
            new Dialogue("스승", "적의 본거지인 폭포 마을의 가장 깊은 곳, 그 근원 바로 앞까지 홀로 다다랐구나."),
            new Dialogue("주인공", "...스승님. 피로 물든 폭포 아래에서 싸우며 깨달았습니다. 제가 베어 넘겨온 것은 악귀가 아니라... 사원이 지켜야 했을 무고한 사람들이었습니다."),
            new Dialogue("주인공", "어째서 제게 이런 광기를 강요하신 겁니까?! 스승님이 말씀하신 '단죄'의 진짜 의미는 도대체 무엇입니까!"),
            new Dialogue("스승", "마기가 네 의식을 완전히 갉아먹어 마침내 나까지 의심하게 만들었군. 허나 이 마지막 순간에 주저하는 것은 헛된 일이다."),
            new Dialogue("스승", "폭포 마을 깊은 곳에서 사원을 위협하는 모든 거짓의 원흉, 그 우두머리를 홀로 단죄해라. 그자의 목을 쳐야만 이 지독한 환영이 끝날 것이다.")
        },

        [VILLAGE_TEACHER_17] = new List<Dialogue>()
        {
            // 3챕터 최종보스(폭포 마을 우두머리) 클리어 후 마을 복귀 - 사원 소멸, 불타는 마을 재현 (최종장 1관문)
            new Dialogue("주인공", "...스승님, 돌아왔습니다. 폭포 마을의 마물과 그 우두머리까지 모두 단죄했습니다."),
            new Dialogue("스승", "..."),
            new Dialogue("주인공", "하지만... 우두머리를 벤 자리에 남은 건 빛바랜 유품들뿐이었습니다. 스승님, 대체 이 피비린내 나는 단죄의 끝에 무엇이 남는 것입니까?"),
            new Dialogue("스승", "이제야... 네 둔해진 눈이 꺼풀을 벗기 시작했구나."),
            new Dialogue("주인공", "예...? 그게 무슨 말씀이십니까?"),
            new Dialogue("스승", "사원 같은 건 처음부터 없었다. 네가 그토록 지키고자 했던 사원도, 내가 부여한 수련도... 전부 네 죄책감이 만들어낸 허상일 뿐이다."),
            new Dialogue("주인공", "아닙니다! 스승님은 지금 제 눈앞에 이렇게 멀쩡히 서 계시지 않습니까! 저와 이야기를 나누고 있지 않습니까!"),
            new Dialogue("스승", "나는 이미 오래전에, 네 폭주하는 검에 맞아 죽었다."),
            new Dialogue("스승", "네가 이 길을 걸으며 베어 넘긴 건 괴물이 아니다. 나였고, 동료들이었고... 무고한 마을 사람들이었다."),
            new Dialogue("주인공", "...아니야. 아니야... 거짓말입니다! 스승님!!"),
            new Dialogue("스승", "부정한다고 사라질 진실이었다면... 애초에 네 눈에 환영이 보이지도 않았을 것이다."),
            new Dialogue("스승", "더 이상 본당의 헛된 정적 뒤에 숨지 마라. 밖으로 나가거라. 네 손으로 직접 빚어낸 진짜 현실을... 그 눈으로 똑똑히 마주하거라."),
            new Dialogue("주인공", "말도 안 됩니다... 제 눈으로 직접 확인하겠습니다!")
        },

        [VILLAGE_TEACHER_18] = new List<Dialogue>() { },
        [VILLAGE_TEACHER_19] = new List<Dialogue>() { },
        [VILLAGE_TEACHER_20] = new List<Dialogue>() { }
    };

    public static List<Dialogue> Get(string key)
    {
        return Stories.TryGetValue(key, out var story) ? story : null;
    }

    public static bool Exists(string key)
    {
        return Stories.ContainsKey(key);
    }
}