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
		    new Dialogue("친구", "첫 싸움을 마치고 무사히 돌아왔구나! 숲 외곽에 적들이 정말 그렇게 많았어? 어디 다친 데는 없고?"),
            new Dialogue("주인공", "...몸은 무사하다. 하지만 이상하게도... 검이 적의 몸을 베어 가를 때마다 가슴 한구석이 통증으로 비명을 지르는 듯했어."),
            new Dialogue("주인공", "베어진 자들의 눈빛에서 나를 향한 깊은 원망과 절규가 느껴졌다. 마치... 손끝이 덜덜 떨릴 정도로."),
            new Dialogue("친구", "오랜만의 실전이라 긴장해서 잔상이 남은 걸 거야. 넌 사원을 지키는 일을 한 거라고! 어서 스승님께 가 봐, 기다리셔.")
        },

        [VILLAGE_FRIEND_3] = new List<Dialogue>()
        {
            // 1챕터 Stage 4 클리어 후 - 친구 대화
			new Dialogue("친구", "이제 곧 숲 가장 깊은 곳의 우두머리와 싸우러 가는 거지? ...너, 얼굴빛이 왜 그렇게 유령처럼 차가워? 진짜 괜찮은 거야?"),
            new Dialogue("주인공", "...친구여. 내가 베어넘긴 수많은 적들의 얼굴이, 쓰러지며 남긴 마지막 말이... 자꾸만 내 기억 속 사람들과 겹쳐 보인다."),
            new Dialogue("주인공", "내가 베어내고 있는 것이... 정말 사원을 위협하는 '적'이 맞기는 한 걸까?"),
            new Dialogue("친구", "무... 무슨 소리를 하는 거야! 넌 사원과 우리를 지키기 위해 싸우는 거라고! 더 이상 이상한 소리 하지 마!"),
            new Dialogue("친구", "얼른 스승님께 가 봐. 수련을 완수해야 이 악몽도 끝날 거 아니야... 얼른!")
        },

        [VILLAGE_FRIEND_4] = new List<Dialogue>()
        {
            // 1챕터 Stage 5 클리어 후 - 친구 대화
			new Dialogue("친구", "대나무 숲의 우두머리를 물리쳤다고 들었어! 무사히 해냈구나, 정말 장해! 이제 숲의 위협도 한시름 놓았어."),
            new Dialogue("주인공", "...친구여. 우두머리를 베어 넘겼을 때, 녀석의 눈빛은 적의가 아니라 슬픔으로 차 있었다."),
            new Dialogue("주인공", "그 녀석이 쓰러지며 내 손을 잡으려 했어... 그리고 내 이름을 불렀다. 네 눈에는 대체 저게 무엇으로 보인 거지?"),
            new Dialogue("주인공", "...그리고 너는 왜 아까부터 손을 그렇게 경련하듯 떨고 있는 건가? 땀마저 흐르고 있잖아."),
            new Dialogue("친구", "아... 아무것도 아니야! 숲의 바람이 차서... 그냥 몸이 좀 떨린 것뿐이라고! 이상한 질문 좀 그만해!"),
            new Dialogue("친구", "어서 스승님을 뵈러 가! 다음 지역으로 가라고 하실 거 아니야! 얼른!")
        },

        [VILLAGE_FRIEND_5] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_6] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_7] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_8] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_9] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_10] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_11] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_12] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_13] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_14] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_15] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_16] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_17] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_18] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_19] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_20] = new List<Dialogue>()
        {

        },


        //스승
        [VILLAGE_TEACHER_1] = new List<Dialogue>()
        {
            // 사원 본당 - 스승과의 첫 대화
            new Dialogue("스승", "눈빛이 붉게 젖어 있구나. 본당에 들어설 때부터 거친 숨소리와 음산한 기운이 여기까지 느껴진다."),
            new Dialogue("주인공", "...스승님. 제 내면의 소용돌이를 다스릴 수가 없습니다. 억눌러온 검기가... 제 의지와 상관없이 폭주하려 합니다."),
            new Dialogue("스승", "마음의 균형이 깨지면 결국 검이 주인을 휘두르고, 내면의 깊은 어둠이 너를 집어삼키는 법이니라."),
            new Dialogue("스승", "당장 마당으로 가거라. 수련용 목석을 베며 분노가 아닌 칼날의 감각과 순수한 호흡에 집중하여 마음을 가다듬어라."),
            new Dialogue("주인공", "...예, 스승님. 잡념을 털어내고 내면의 살기를 가라앉힌 뒤 다시 올리겠습니다.")
        },

        [VILLAGE_TEACHER_2] = new List<Dialogue>()
        {
            // 사원 본당 - 목석 수련 완료 후 첫 퀘스트 수령
            new Dialogue("주인공", "...스승님, 목석을 모두 베어넘겼습니다. 칼끝의 감각을 세우며... 폭주하던 호흡을 조금은 다스렸습니다."),
            new Dialogue("스승", "좋다. 칼끝의 미세한 떨림이 비로소 안정을 찾았구나. 분노에 안개를 씌우지 않는 것이 검사의 기본이다."),
            new Dialogue("스승", "하지만 방심하긴 이르다. 최근 사원 외곽의 대나무 숲에 정체불명의 적들이 침입했다는 기괴한 소문이 들린다."),
            new Dialogue("주인공", "사원을 노리는 적들입니까... 제 검으로 즉시 단죄하겠습니다."),
            new Dialogue("스승", "숲으로 나아가 적 5명을 베어넘겨라. 네 칼날이 사사로운 정에 흔들리지 않음을 실전에서 증명하고 오거라."),
            new Dialogue("주인공", "명심하겠습니다. 사원의 평화를 어지럽히는 무리를 모두 소탕하고 돌아오겠습니다.")
        },

        [VILLAGE_TEACHER_3] = new List<Dialogue>()
        {
         // 1챕터 Stage 1 클리어 후 - 스승 대화 (퀘스트 수령)
		    new Dialogue("스승", "첫 번째 실전을 치르고 왔구나. 하지만 네 눈빛을 보니 여전히 칼끝에 자비와 망설임이 서려 있다."),
            new Dialogue("주인공", "...스승님. 적을 베어넘길 때마다 가슴속에서 알 수 없는 죄책감과 슬픔이 솟구쳐 올랐습니다. 그들은 대체 누구입니까?"),
            new Dialogue("스승", "네 안의 사악한 마기가 정념을 어지럽혀 환상을 만들어내는 것이다. 마음을 비우지 못하면 네 검이 먼저 부러질 것이다."),
            new Dialogue("스승", "더 베어넘겨라. 대나무 숲 깊은 곳으로 들어가 적 5명을 더 처치하고 마음의 흔들림을 털어내라.")
        },

        [VILLAGE_TEACHER_4] = new List<Dialogue>()
        {
            // 1챕터 Stage 2 클리어 후 - 스승 대화 (퀘스트 수령)
			new Dialogue("스승", "돌아왔구나. 네 칼 끝에 묻어나는 기운이 이전보다 한층 더 무겁고 짙어졌느니라."),
            new Dialogue("주인공", "...스승님. 억지로 검을 휘두르다 보니... 점차 가슴을 짓누르던 죄책감도, 손끝의 감각도 무뎌져 가는 기분입니다."),
            new Dialogue("주인공", "피비린내 속에서 점점 감정을 잃어가는 제 모습이... 때로는 무섭게 느껴집니다."),
            new Dialogue("스승", "사사로운 감정을 털어내고 냉정해지는 것이 바로 무도(武道)의 길이자, 사원을 지키는 검사의 운명이다."),
            new Dialogue("스승", "멈추지 마라. 대나무 숲의 적 5명을 더 처치하여 네 내면의 찌꺼기를 모두 태워버리거라.")
        },

        [VILLAGE_TEACHER_5] = new List<Dialogue>()
        {
            // 1챕터 Stage 3 클리어 후 - 스승 대화 (퀘스트 수령)
			new Dialogue("스승", "호흡과 검의 궤적이 한결 단정해졌구나. 이제야 제법 망설임 없는 검사의 기틀이 보이는구나."),
            new Dialogue("주인공", "...스승님, 감각은 또렷해졌으나 환각이 심해지고 있습니다. 적들이 쓰러지며 내뱉는 비명이..."),
            new Dialogue("주인공", "마치 오랫동안 저를 알고 지내던 사원 사람들의 절규처럼 귓가를 찢발깁니다. 숲의 안개마저 핏빛으로 보입니다."),
            new Dialogue("스승", "네 마음의 약함과 죄책감이 빚어낸 환상에 불과하다. 의지를 더욱 굳건히 하여 잔향에 마음을 빼앗기지 마라."),
            new Dialogue("스승", "숲의 깊은 안개 속으로 더 나아가라. 적 5명을 더 처치하고 허상을 베어내는 의지를 증명해라.")
        },

        [VILLAGE_TEACHER_6] = new List<Dialogue>()
        {
            // 1챕터 Stage 4 클리어 후 - 스승 대화 (퀘스트 수령)
			new Dialogue("스승", "마침내 대나무 숲의 가장 깊은 안개 속, 그 근원 앞까지 도달했구나."),
            new Dialogue("주인공", "...스승님. 숲 저 깊은 안개 너머에서 차가운 살기와 함께 나를 짓누르는 참담한 원망이 느껴집니다."),
            new Dialogue("스승", "대나무 숲을 지배하며 온갖 기괴한 환영과 기운을 퍼뜨리는 우두머리가 기다리고 있다."),
            new Dialogue("스승", "망설임 없이 그자의 목을 베어 수련을 완수해라. 그 거대한 잔향을 끊어내야 네 검이 비로소 완성될 것이다.")
        },

        [VILLAGE_TEACHER_7] = new List<Dialogue>()
        {
            // 1챕터 Stage 5 클리어 후 - 스승 대화 (2챕터 퀘스트 수령)
			new Dialogue("스승", "대나무 숲의 우두머리를 베어넘기고 마침내 첫 번째 시련을 넘어섰구나. 장하다."),
            new Dialogue("주인공", "...스승님. 우두머리가 쓰러지며 내뱉은 마지막 유언이... 마치 오랫동안 저를 깊이 아끼고 걱정해 주던 사람의 목소리였습니다."),
            new Dialogue("주인공", "이 괴로움이... 정말 단지 제 마음이 약해서 생기는 환각일 뿐입니까? 제 손에 묻은 피가 너무나도 차갑게 느껴집니다."),
            new Dialogue("스승", "마기에 짓눌린 칼날과 네 죄책감이 만들어낸 지독한 잔향일 뿐이다. 동요하는 순간 네 영혼마저 침식될 것이다."),
            new Dialogue("스승", "돌아보지 마라. 이제 다음 지역인 '참나무 숲'으로 이동하여, 그곳에 침입한 적 5명을 처치하고 칼날을 더욱 날카롭게 다스려라.")
        },

        [VILLAGE_TEACHER_8] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_9] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_10] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_11] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_12] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_13] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_14] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_15] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_16] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_17] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_18] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_19] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_20] = new List<Dialogue>()
        {

        }


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