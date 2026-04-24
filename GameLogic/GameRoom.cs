using System;
using System.Collections.Generic;

// 게임 룸(Park) 관리 클래스
public class GameRoom
{
    public static GameRoom Instance { get; } = new GameRoom(); // 싱글톤 패턴

    private List<Session> _sessions = new List<Session>();
    private object _lock = new object();

    // 유저 입장
    public void Enter(Session session)
    {
        lock (_lock)
        {
            _sessions.Add(session);

            // 공원에 있는 유저들 정보 나에게 전송
            /* foreach (Session other in _sessions)
            {
                S_Spawn spawnPacket = new S_Spawn
                {
                    playerId = other.UserId,
                    weaponIdx = other.WeaponId
                };
                session.Send(spawnPacket.Write()); // 새로 들어온 나(session)에게만 전송

                // Console.WriteLine($"기존 유저의 spawn 패킷 전달: {session.Nickname}, {session.WeaponId}");
            }*/
        }
    }

    // 유저 퇴장
    public void Leave(Session session)
    {
        lock (_lock) { _sessions.Remove(session); }
    }

    // 패킷 브로드캐스트
    public void Broadcast(ArraySegment<byte> packet, Session? exceptMe)
    {
        lock (_lock)
        {
            foreach (Session s in _sessions)
            {
                if (s != exceptMe)
                    s.Send(packet);
            }
        }
    }
}