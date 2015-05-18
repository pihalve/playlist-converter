namespace Pihalve.PlaylistConverter.Application.Domain.Rules
{
    public abstract class BaseParenthesesPartsProcessorRule : BaseProcessorRule
    {
        protected BaseParenthesesPartsProcessorRule(bool active)
            : base(active)
        {
        }

        protected virtual string RemoveParenthesesParts(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int startIdx = value.IndexOf('(');
                if (startIdx > -1)
                {
                    int endIdx = value.IndexOf(')', startIdx);
                    endIdx = endIdx > -1 ? endIdx : value.Length - 1;
                    value = value.Remove(startIdx, endIdx - startIdx + 1).Trim();
                    startIdx = value.IndexOf('(');
                    if (startIdx > -1)
                    {
                        value = RemoveParenthesesParts(value);
                    }
                }
            }
            return value;
        }

        //public override void Apply(PlaylistItem playlistItem)
        //{
        //    string[] props = PropertyPath.Split('.');
        //    object parentObj = null;
        //    object childObj = null;
        //    for (int i = 0; i < props.Length; i++)
        //    {
        //        if (i == 0)
        //        {
        //            parentObj = playlistItem;
        //            childObj = playlistItem.GetType().GetProperty(props[i]).GetValue(playlistItem);
        //        }
        //        else if (childObj != null)
        //        {
        //            parentObj = childObj;
        //            childObj = childObj.GetType().GetProperty(props[i]).GetValue(childObj);
        //        }

        //        if (i == props.Length - 1 && childObj != null)
        //        {
        //            parentObj.GetType().GetProperty(props[i]).SetValue(parentObj, RemoveParenthesesParts((string)childObj));
        //        }
        //    }
        //}
    }
}
