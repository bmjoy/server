﻿using GameServer.Script.CsScript.Action;
using GameServer.Script.Model.DataModel;
using GameServer.Script.Model.Enum;
using ZyGames.Framework.Game.Service;

namespace GameServer.CsScript.Action
{

    /// <summary>
    /// 8003_切磋完毕
    /// </summary>
    public class Action8003 : BaseAction
    {
        private EventStatus Result;
       
        public Action8003(ActionGetter actionGetter)
            : base(ActionIDDefine.Cst_Action8003, actionGetter)
        {
            IsNotRespond = true;
        }

        public override bool GetUrlElement()
        {
            if (httpGet.GetEnum("Result", ref Result))
            {
                return true;
            }
            return false;
        }

        public override bool TakeAction()
        {
            ContextUser.UserStatus = UserStatus.MainUi;
            ContextUser.InviteFightDestUid = 0;

            if (Result == EventStatus.Good)
            {
                UserHelper.GiveAwayDiamond(ContextUser.UserID, DataHelper.InviteFightAwardDiamond);
            }
            return true;
        }
    }
}