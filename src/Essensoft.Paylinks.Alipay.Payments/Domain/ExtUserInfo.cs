using System.Text.Json.Serialization;

namespace Essensoft.Paylinks.Alipay.Payments.Domain;

public class ExtUserInfo
{
    /// <summary>
    /// 买家证件号。 注：need_check_info&#x3D;T或fix_buyer&#x3D;T时该参数才有效，支付宝会比较买家在支付宝留存的证件号码与该参数传入的值是否匹配。
    /// </summary>
    [JsonPropertyName("cert_no")]
    public string? CertNo { get; set; }

    /// <summary>
    /// 指定买家证件类型。 枚举值：IDENTITY_CARD：身份证； PASSPORT：护照； OFFICER_CARD：军官证； SOLDIER_CARD：士兵证； HOKOU：户口本； PERMANENT_RESIDENCE_FOREIGNER：外国人永久居留身份证。 如有其它类型需要支持，请与蚂蚁金服工作人员联系。 注：need_check_info&#x3D;T或fix_buyer&#x3D;T时该参数才有效，支付宝会比较买家在支付宝留存的证件类型与该参数传入的值是否匹配。
    /// </summary>
    [JsonPropertyName("cert_type")]
    public string? CertType { get; set; }

    /// <summary>
    /// 是否强制校验买家身份。 需要强制校验传：T; 不需要强制校验传：F或者不传； 当传T时，接口上必须指定cert_type、cert_no和name信息且支付宝会校验传入的信息跟支付买家的信息都匹配，否则报错。 默认为不校验。
    /// </summary>
    [JsonPropertyName("fix_buyer")]
    public string? FixBuyer { get; set; }

    /// <summary>
    /// 买家加密身份信息。当指定了此参数且指定need_check_info&#x3D;T时，支付宝会对买家身份进行校验，校验逻辑为买家姓名、买家证件号拼接后的字符串，以sha256算法utf-8编码计算hash，若与传入的值不匹配则会拦截本次支付。注意：如果同时指定了用户明文身份信息（name，cert_type，cert_no中任意一个），则忽略identity_hash以明文参数校验。
    /// </summary>
    [JsonPropertyName("identity_hash")]
    public string? IdentityHash { get; set; }

    /// <summary>
    /// 允许的最小买家年龄。 买家年龄必须大于等于所传数值  注：1. need_check_info&#x3D;T时该参数才有效 2. min_age为整数，必须大于等于0
    /// </summary>
    [JsonPropertyName("min_age")]
    public string? MinAge { get; set; }

    /// <summary>
    /// 指定买家手机号。 注：该参数暂不校验
    /// </summary>
    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    /// <summary>
    /// 指定买家姓名。 注：need_check_info&#x3D;T或fix_buyer&#x3D;T时该参数才有效
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// 是否强制校验买家信息； 需要强制校验传：T; 不需要强制校验传：F或者不传； 当传T时，支付宝会校验支付买家的信息与接口上传递的cert_type、cert_no、name或age是否匹配，只有接口传递了信息才会进行对应项的校验；只要有任何一项信息校验不匹配交易都会失败。如果传递了need_check_info，但是没有传任何校验项，则不进行任何校验。 默认为不校验。
    /// </summary>
    [JsonPropertyName("need_check_info")]
    public string? NeedCheckInfo { get; set; }
}
