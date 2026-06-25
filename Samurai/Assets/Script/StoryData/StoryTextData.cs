using System.Collections.Generic;

public static class StoryDatabase
{
    public const string VILLAGE_FRIEND_1 = "village_friend_1";
    public const string VILLAGE_FRIEND_2 = "village_friend_2";
    public const string VILLAGE_FRIEND_3 = "village_friend_3";
    public const string VILLAGE_FRIEND_4 = "village_friend_4";
    public const string VILLAGE_FRIEND_5 = "village_friend_5";

    public const string VILLAGE_TEACHER_1 = "village_teacher_1";
    public const string VILLAGE_TEACHER_2 = "village_teacher_2";
    public const string VILLAGE_TEACHER_3 = "village_teacher_3";
    public const string VILLAGE_TEACHER_4 = "village_teacher_4";
    public const string VILLAGE_TEACHER_5 = "village_teacher_5";


    public static readonly Dictionary<string, List<Dialogue>> Stories = new()
    {

        // 친구
        [VILLAGE_FRIEND_1] = new List<Dialogue>()
        {
            new("친구", "...또 그 꿈인가?"),
            new("나", "(여전히 떨리는 손으로 칼자루를 꽉 쥔 채...)"),
            new("친구", "식은땀까지 흘리는 걸 보니 보통 악몽이 아니었나 보군."),
            new("주인공", "...모두가 사라졌다. 너도, 스승님도."),
            new("친구", "꿈은 현실과 반대라고 하잖아."),
            new("주인공", "...그래. 다행이군."),
            new("친구", "스승님께서 본당에서 너를 찾고 계신다."),
            new("주인공", "..스승님이 나를?"),
            new("친구", "얼른 본당으로 가봐.")
        },

        [VILLAGE_FRIEND_2] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_3] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_4] = new List<Dialogue>()
        {

        },

        [VILLAGE_FRIEND_5] = new List<Dialogue>()
        {

        },


        //스승
        [VILLAGE_TEACHER_1] = new List<Dialogue>()
        {
            new("스승", "눈빛이 흔들리는구나. 또 난세의 불꽃을 보았느냐."),
            new("주인공", "......면목 없습니다. 잡념을 떨쳐내지 못했습니다."),
            new("스승", "검사가 칼날에 잡념을 담으면 목숨을 잃는 법. 그 어지러운 호흡을 다스리기엔 이곳의 공기가 너무 평온하구나."),
            new("주인공", "...가르침을 주십시오."),
            new("스승", "북쪽 대나무 숲 너머에 있는 '버려진 하천 사원(Abandoned River Shrine)'으로 가거라. 최근 그곳을 거점으로 삼은 무법자들과 들개들이 사원의 영역을 침범하고 있다."),
            new("스승", "그곳에서 날뛰는 자들을 베어 넘기며, 네 마음속의 어지러운 잔향을 지우고 오너라. 이것이 오늘의 수련이다."),
            new("주인공", "...알겠습니다. 다녀오겠습니다.")
        },

        [VILLAGE_TEACHER_2] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_3] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_4] = new List<Dialogue>()
        {

        },

        [VILLAGE_TEACHER_5] = new List<Dialogue>()
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